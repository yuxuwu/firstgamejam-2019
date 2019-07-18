using UnityEngine.UI;
using UnityEngine;

public class ChoiceInterface : MonoBehaviour
{
    int targetID;
    Text text;

    InputManager im;

    [SerializeField] int index = 0;

    void Start()
    {
        text = transform.Find("Text").GetComponent<Text>();
        im = GameObject.Find("Managers").GetComponent<InputManager>();

        Disable();
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
    
    public void SetChoice(string text, int targetID)
    {
        this.text.text = text;
        this.targetID = targetID;
    }

    public int GetID()
    {
        return targetID;
    }

    public void OnClick()
    {
        Debug.Log("Clicked choice " + index.ToString());
        im.OnChoiceSelected(targetID, index);
    }
}