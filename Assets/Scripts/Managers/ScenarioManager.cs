using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    public class Choice
    {
        public string choiceText {get; private set;}
        public int targetID {get; private set;}

        public Choice (string choiceText, int targetID)
        {
            this.choiceText = choiceText;
            this.targetID = targetID;
        }
    }

    [SerializeField] ScenarioGraph _scenario = null;

    private IDNodeBase _currentNode;
    private List<Choice> _choices;
    private IDictionary<string, bool> _switches;

    private IDNodeBase recordedNode;

    void Start()
    {
        _currentNode = _scenario.GetStartNode();
        _choices = new List<Choice>();
        _switches = _scenario.GetSwitches();
    }

    public void AdvanceCurrentNode()
    {
        _currentNode = _currentNode.GetNextNode();
    }

    public IDNodeBase GetCurrentNode()
    {
        return _currentNode;
    }
    
    public void AddChoice(string choiceText, int targetID)
    {
        _choices.Add(new Choice(choiceText, targetID));
    }

    public List<Choice> GetChoices()
    {
        List<Choice> choices = new List<Choice>();
        // Retrive top 3 choices
        for(int i = 0; i < 3; i++)
        {
            if (_choices[i] != null)
            {
                choices.Add(_choices[i]);
            }
        }
        return choices;
    }

    public void RemoveChoice(int index)
    {
        _choices.RemoveAt(index);
    }

    public void Jump(int targetID)
    {
        recordedNode = _currentNode;        
        _currentNode = _scenario.GetNodeByID(targetID) as IDNodeBase;
    }

    public void Return()
    {
        _currentNode = recordedNode;
    }

    public void AdvanceByNode(IDNodeBase node)
    {
        Debug.Log(node.id);
        _currentNode = node;
    }

    public bool CheckSwitch(string switchName)
    {
        return _switches[switchName];
    }

    public void SetSwitch(string swtichName, bool bo)
    {
        _switches[swtichName] = bo;
    }

}
