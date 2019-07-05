using UnityEngine.UI;
using UnityEngine;

public class TextboxInterface : MonoBehaviour
{
    public void SetSpeakerName(string str)
    {
       transform.Find("Speaker Name").GetComponent<Text>().text = str;
    }

    public void SetText(string str)
    {
        transform.Find("Text").GetComponent<Text>().text = str;
    }
}
