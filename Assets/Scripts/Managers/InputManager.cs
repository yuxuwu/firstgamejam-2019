using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private enum State {
        Processing,

        DisplayingSpeech,

        DisplayingMainChoices,

        DisplayingSimpleChoices,
        
        End
    }

    [SerializeField] private State state;

    [SerializeField] TextboxInterface m_textbox;
    [SerializeField] ChoiceInterface m_choice0;
    [SerializeField] ChoiceInterface m_choice1;
    [SerializeField] ChoiceInterface m_choice2;

    private ScenarioManager m_scenario;
    private bool m_OkayToProceedText = true;

    private void Start()
    {
       m_scenario  = GetComponent<ScenarioManager>();
       state = State.Processing;
    }

    private void Update()
    {
        if (CheckInputSubmitUp())
        {
            m_OkayToProceedText = true;
        }
 
        switch (state)
        {
            case State.Processing:
                _ProcessNode(m_scenario.GetCurrentNode());
                break;

            case State.DisplayingSpeech:
                if (CheckInputSubmitDown() && m_OkayToProceedText)
                {
                    switch (m_textbox.state)
                    {
                        case TextboxInterface.State.Typing:
                            __ProcessSpeechNodeSet(m_scenario.GetCurrentNode());
                            break;
                        case TextboxInterface.State.Done:
                            m_textbox.SignalWaiting();
                            m_scenario.AdvanceCurrentNode();
                            state = State.Processing;
                            break;
                    }
                }
                break;
            
            case State.DisplayingMainChoices:
                // Do nothing, wait for OnChoiceSelected
                break;
 
        }

    }

    // START: Public Methods
    public void OnChoiceSelected(int targetID, int index)
    {
        if (state == State.DisplayingMainChoices)
        {
            // Change current node to target node
            m_scenario.Jump(targetID);
            m_scenario.RemoveChoice(index);
            DisableChoices();
            state = State.Processing;
        }
    }
    // END: Public Methods

    // START: Utility Methods
    private void DisableChoices()
    {
        m_choice0.Disable();
        m_choice1.Disable();
        m_choice2.Disable();
    }

    private bool CheckInputSubmitUp()
    {
        return Input.GetButtonUp("Submit") || Input.GetMouseButtonUp(0);
    }

    private bool CheckInputSubmitDown()
    {
        return Input.GetButtonDown("Submit") || Input.GetMouseButtonDown(0);
    }
    // END: Utility Methods

    private void _ProcessNode(IDNodeBase node)
    {
        if (node is SpeechNode)
        {
            __ProcessSpeechNode(node);
        }
        else if (node is StartNode)
        {
            __ProcessStartNode(node);
        }
        else if (node is AddChoiceNode)
        {
            __ProcessAddChoiceNode(node);
        }
        else if (node is DisplayChoices)
        {
            __ProcessDisplayChoicesNode(node);
        }
        else if (node is StartChoiceNode)
        {
            // Same behavior as StartNode
            __ProcessStartNode(node); 
        }
        else if (node is EndChoiceNode)
        {
            __ProcessEndChoiceNode(node);
        }
        else if (node is SwitchNode)
        {
            __ProcessSwitchNode(node);
        }
        else if (node is EndNode)
        {
            __ProcessEndNode(node);
        }
        else
        {
            Debug.Log("Node" + node.id.ToString() + " not yet implemented!!");
        }
    }

    /// START: Speech Node
    private void __ProcessSpeechNode(IDNodeBase _node)
    {
        SpeechNode node = (SpeechNode) _node;
        m_textbox.SetSpeakerName(node.SpeakerName);
        m_textbox.SetTextType(node.Text);

        state = State.DisplayingSpeech;
    }

    private void __ProcessSpeechNodeSet(IDNodeBase _node)
    {
        SpeechNode node = (SpeechNode) _node;
        m_textbox.SetSpeakerName(node.SpeakerName);
        m_textbox.SetText(node.Text);
    }
    /// END: Speech Node

    private void __ProcessAddChoiceNode(IDNodeBase _node)
    {
        AddChoiceNode node = (AddChoiceNode) _node;
        m_scenario.AddChoice(node.ChoiceText, node.TargetID);
        m_scenario.AdvanceCurrentNode();
        m_scenario.SetSwitch("IsChoicesEmpty", false);
    }

    private void __ProcessStartNode(IDNodeBase _node)
    {
        m_scenario.AdvanceCurrentNode();
        Debug.Log("On Start Node");
    }

    private void __ProcessEndChoiceNode(IDNodeBase _node)
    {
        EndChoiceNode node = (EndChoiceNode) _node;
        // Return to original node + 1
        m_scenario.Return();
        m_scenario.AdvanceCurrentNode();
    }

    private void __ProcessDisplayChoicesNode(IDNodeBase _node)
    {
        DisplayChoices node = (DisplayChoices) _node;
        List<ScenarioManager.Choice> choices = m_scenario.GetChoices();
        if (choices.Count > 0)
        {
            state = State.DisplayingMainChoices;

            m_choice0.SetChoice(choices[0].choiceText, choices[0].targetID);
            m_choice0.Enable();
            if (choices.Count > 1) 
            {
                m_choice1.SetChoice(choices[1].choiceText, choices[1].targetID);
                m_choice1.Enable();
                if (choices.Count > 2)
                {
                    m_choice2.SetChoice(choices[2].choiceText, choices[2].targetID);
                    m_choice2.Enable();
                }
            }
        }
    }

    private void __ProcessSwitchNode(IDNodeBase _node)
    {
        SwitchNode node = (SwitchNode) _node;
        if (m_scenario.CheckSwitch(node.SwitchName))
        {
            m_scenario.AdvanceByNode(node.GetTrueNext());
        }
        else
        {
            m_scenario.AdvanceByNode(node.GetFalseNext());
        }
    }

    private void __ProcessEndNode(IDNodeBase _node)
    {
        EndNode node = (EndNode) _node;
        state = State.End;
        Debug.Log("We've hit the end!");
    }

}
