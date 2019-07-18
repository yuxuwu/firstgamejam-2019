using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextboxInterface : MonoBehaviour
{
    Text speaker;
    Text text;

    public enum State {Waiting, Typing, Done}
    public State state {get; private set;}

    void Start()
    {
        speaker = transform.Find("Speaker Name").GetComponent<Text>();
        text = transform.Find("Text").GetComponent<Text>();
        state = State.Waiting;
    }
    
    public void SignalWaiting()
    {
        state = State.Waiting;
    }

    public void SetSpeakerName(string str)
    {
       speaker.text = str;
    }

    public void SetText(string str)
    {
        StopAllCoroutines();
        text.text = str;
        state = State.Done;
    }

    public void SetTextType(string str)
    {
        StopAllCoroutines();
        state = State.Typing;
        StartCoroutine(TypeText(str));
    }
    
    private IEnumerator TypeText(string str)
    {
        text.text = "";
        foreach (char c in str.ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(.01f);
        }
        state = State.Done;
        yield return null;
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
