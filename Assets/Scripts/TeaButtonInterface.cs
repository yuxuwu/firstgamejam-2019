using UnityEngine;

public class TeaButtonInterface : MonoBehaviour
{
    
    void Start()
    {
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
    }
}
