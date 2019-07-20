using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class StatsManager : MonoBehaviour
{

    public int Jealousy {get; private set;}
    public int Pride {get; private set;}
    public int Ambition {get; private set;}

    UIEmotionInterface emoInterface;
    RectTransform emoTracker;

    void Start()
    {
        /// Debug
        Jealousy = 10;
        Pride = 10;
        Ambition = 10;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Detected scene loaded: " + scene.name);
        if (scene.name == "TeaMinigame")
        {

            emoInterface = GameObject.Find("Character/Emotion UI/UIEmotionTracker").GetComponent<UIEmotionInterface>();
            emoTracker = GameObject.Find("Canvas/Emotion Tracker").GetComponent<RectTransform>();
            RefreshTracker();
        }
    }

    private void RefreshTracker()
    {
        emoTracker.Find("Jealousy").Find("Val").GetComponent<Text>().text = Jealousy.ToString();
        emoTracker.Find("Pride").Find("Val").GetComponent<Text>().text = Pride.ToString();
        emoTracker.Find("Ambition").Find("Val").GetComponent<Text>().text = Ambition.ToString();
    }

    public void AddJealousy(int val)
    {
        Jealousy = Mathf.Clamp(Jealousy + val, 0, 20);
        emoInterface.RecalcDotPos();
        RefreshTracker();
    }

    public void SubJealousy(int val)
    {
        Jealousy = Mathf.Clamp(Jealousy - val, 0, 20);
        emoInterface.RecalcDotPos();
        RefreshTracker();
    }

    public void AddPride(int val)
    {
        Pride = Mathf.Clamp(Pride + val, 0, 20);
        emoInterface.RecalcDotPos();
        RefreshTracker();
    }

    public void SubPride(int val)
    {
        Pride = Mathf.Clamp(Pride - val, 0, 20);
        emoInterface.RecalcDotPos();
        RefreshTracker();
    }

    public void AddAmbition(int val)
    {
        Ambition = Mathf.Clamp(Ambition + val, 0, 20);
        emoInterface.RecalcDotPos();
        RefreshTracker();
    }

    public void SubAmbition(int val)
    {
        Ambition = Mathf.Clamp(Ambition - val, 0, 20);
        emoInterface.RecalcDotPos();
        RefreshTracker();
    }
}
