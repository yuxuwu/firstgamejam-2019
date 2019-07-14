using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    [SerializeField] ScenarioGraph _scenario = null;

    private IDNodeBase _currentNode;

    void Start()
    {
        _currentNode = _scenario.GetStartNode();
    }

    public void AdvanceCurrentNode()
    {
        _currentNode = _currentNode.GetNextNode();
    }

    public IDNodeBase GetCurrentNode()
    {
        return _currentNode;
    }
}
