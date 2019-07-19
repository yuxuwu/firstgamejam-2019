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
        Jealousy = 30;
        Pride = 30;
        Ambition = 30;

        emoInterface = GameObject.Find("Character/Emotion UI/UIEmotionTracker").GetComponent<UIEmotionInterface>();
        emoTracker = GameObject.Find("Canvas/Emotion Tracker").GetComponent<RectTransform>();
        RefreshTracker();
    }

    private void RefreshTracker()
    {
        emoTracker.Find("Jealousy").Find("Val").GetComponent<Text>().text = Jealousy.ToString();
        emoTracker.Find("Pride").Find("Val").GetComponent<Text>().text = Pride.ToString();
        emoTracker.Find("Ambition").Find("Val").GetComponent<Text>().text = Ambition.ToString();
    }

    public void AddJealousy(int val)
    {
        Jealousy += val;
        emoInterface.RecalcDotPos();
        RefreshTracker();
    }

    public void SubJealousy(int val)
    {
        Jealousy -= val;
        emoInterface.RecalcDotPos();
        RefreshTracker();
    }

    public void AddPride(int val)
    {
        Pride += val;
        emoInterface.RecalcDotPos();
        RefreshTracker();
    }

    public void SubPride(int val)
    {
        Pride -= val;
        emoInterface.RecalcDotPos();
        RefreshTracker();
    }

    public void AddAmbition(int val)
    {
        Ambition += val;
        emoInterface.RecalcDotPos();
        RefreshTracker();
    }

    public void SubAmbition(int val)
    {
        Ambition -= val;
        emoInterface.RecalcDotPos();
        RefreshTracker();
    }
}
