using UnityEngine;
using XNode;

public class ScenarioManager : MonoBehaviour
{
    [SerializeField] ScenarioGraph _scenario = null;
    [SerializeField] TextboxInterface _textbox = null;

    StatsTracker stats;
    Node _currentNode;
    bool _OkayToProceedText = true;

    void Start()
    {
        _currentNode = _scenario.GetStartNode();
        stats = GetComponent<StatsTracker>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit") && _OkayToProceedText)
        {
            _OkayToProceedText = false;
            _ProcessCurrentNode();
        }

        if (Input.GetButtonUp("Submit"))
        {
            _OkayToProceedText = true;
        }
    }

    void _ProcessCurrentNode()
    {
        if(_currentNode is SpeechNode)
        {
            __ProcessSpeechNode();
        }
        else if(_currentNode is ChoiceSpeechNode)
        {
            __ProcessChoiceSpeechNode();
        }
        else if(_currentNode is ChoiceEmotionNode)
        {
            __ProcessChoiceEmotionNode();
        }
        else if(_currentNode is EventNode)
        {
            __ProcessEventNode();
        }
        else if(_currentNode is StartNode)
        {
            __ProcessStartNode();
        }
        else
        {
            Debug.Log("Node not yet implemented!!");
        }
    }

    void __ProcessChoiceSpeechNode()
    {
        ChoiceSpeechNode node = (ChoiceSpeechNode) _currentNode;
        _textbox.SetSpeakerName(node.SpeakerName);
        _textbox.SetText("Choices not yet implemented! Defaulting to choice 1");

        _currentNode = node.GetNextNode(0);
    }

    void __ProcessEventNode()
    {
        EventNode node = (EventNode) _currentNode;
        Debug.Log(node.EventType);

        _currentNode = node.GetNextNode();
    }

    void __ProcessSpeechNode()
    {
        SpeechNode node = (SpeechNode) _currentNode;
        _textbox.SetSpeakerName(node.SpeakerName);
        _textbox.SetText(node.Text);

        _currentNode = node.GetNextNode();
    }

    void __ProcessStartNode()
    {
        StartNode node = (StartNode) _currentNode;
        Debug.Log("On Start Node");

        _currentNode = node.GetNextNode();
    }

    void __ProcessChoiceEmotionNode()
    {
        ChoiceEmotionNode node = (ChoiceEmotionNode) _currentNode;

        if (stats.Jealousy >= node.Jealousy)
        {
            _currentNode = node.GetNextNodeJealousy();
        }
        else if (stats.Pride >= node.Pride)
        {
            _currentNode = node.GetNextNodePride();
        }
        else if (stats.Ambition >= node.Ambition)
        {
            _currentNode = node.GetNextNodeAmbition();
        }
        else
        {
            _currentNode = node.GetNextFail();
        }
    }

}
