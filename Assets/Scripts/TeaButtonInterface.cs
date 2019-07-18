using UnityEngine;

public class TeaButtonInterface : MonoBehaviour
{

    InputManager im;
    
    void Start()
    {
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

    public void OnClick()
    {
        Debug.Log("Loading Tea Minigame");
        im.OnTeaMinigameSelected();
    }
}
