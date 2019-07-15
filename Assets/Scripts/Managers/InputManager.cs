using UnityEngine;

public class InputManager : MonoBehaviour
{
    private enum State {
        DisplayingText, 
        DoneDisplayingText,
        Processing,
    }
    private State state;

    private bool m_OkayToProceedText = true;

    private ScenarioManager m_scenario;

    [SerializeField] TextboxInterface m_textbox;

    void Start()
    {
       m_scenario  = GetComponent<ScenarioManager>();
       state = State.Processing;
    }

    void Update()
    {
        if (CheckInputSubmitUp())
        {
            m_OkayToProceedText = true;
        }
 
        switch (state)
        {
            case State.Processing:
                _ProcessNode(m_scenario.GetCurrentNode());
                // If currentNode requires input to proceed, wait for it
                if (CheckNodeIsSpeechNode(m_scenario.GetCurrentNode()))
                {
                    state = State.DisplayingText;
                }
                else
                {
                    m_scenario.AdvanceCurrentNode();
                }
                break;

            case State.DisplayingText:
                if (CheckInputSubmitDown() && m_OkayToProceedText)
                {
                    // check if text has finished displaying
                    if (m_textbox.state == TextboxInterface.State.Done)
                    {
                        m_textbox.state = TextboxInterface.State.Waiting;
                        state = State.Processing;
                        m_scenario.AdvanceCurrentNode();
                    }
                    // check if text is still typing
                    else if (m_textbox.state == TextboxInterface.State.Typing)
                    {
                        __ProcessSpeechNodeSet(m_scenario.GetCurrentNode());
                    }
                }
                break;
        }

    }

    bool CheckInputSubmitUp()
    {
        return Input.GetButtonUp("Submit") || Input.GetMouseButtonUp(0);
    }

    bool CheckInputSubmitDown()
    {
        return Input.GetButtonDown("Submit") || Input.GetMouseButtonDown(0);
    }

    bool CheckNodeIsSpeechNode(IDNodeBase node)
    {
        if (node is SpeechNode)
            return true;
        return false;
    }

    void _ProcessNode(IDNodeBase node)
    {
        if(node is SpeechNode)
        {
            __ProcessSpeechNode(node);
        }
        else if(node is StartNode)
        {
            __ProcessStartNode(node);
        }
        else
        {
            Debug.Log("Node not yet implemented!!");
        }
    }
    void __ProcessSpeechNode(IDNodeBase _node)
    {
        SpeechNode node = (SpeechNode) _node;
        m_textbox.SetSpeakerName(node.SpeakerName);
        m_textbox.SetTextType(node.Text);
    }

    void __ProcessSpeechNodeSet(IDNodeBase _node)
    {
        SpeechNode node = (SpeechNode) _node;
        m_textbox.SetSpeakerName(node.SpeakerName);
        m_textbox.SetText(node.Text);
    }

    void __ProcessStartNode(IDNodeBase _node)
    {
        StartNode node = (StartNode) _node;
        Debug.Log("On Start Node");
    }
}
