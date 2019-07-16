using UnityEngine.UI;
using UnityEngine;

public class ChoiceInterface : MonoBehaviour
{
    int targetID;
    Text text;

    Button button;
    InputManager im;

    [SerializeField] int index;

    void Start()
    {
        text = transform.Find("Text").GetComponent<Text>();
        button = transform.GetComponent<Button>();
        //button.onClick.AddListener(OnClick);
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