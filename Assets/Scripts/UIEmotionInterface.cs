using System;
using UnityEngine;

public class UIEmotionInterface : MonoBehaviour
{
    Transform JealousyPos = null;
    Transform AmbitionPos = null;
    Transform PridePos = null;
    Transform DotPos = null;
    StatsTracker stats = null;

    void Start()
    {
        Transform emotion_ui = GameObject.Find("Character/Emotion UI").transform;
        JealousyPos = emotion_ui.Find("Jealousy").transform;
        print(JealousyPos);
        PridePos = emotion_ui.Find("Pride").transform;
        AmbitionPos = emotion_ui.Find("Ambition").transform;
        DotPos = emotion_ui.Find("Dot").transform;
        stats = GameObject.Find("Managers").GetComponent<StatsTracker>();

        RecalcDotPos();
    }

    [ExposeMethodInEditor]
    public void RecalcDotPos()
    {
        /// Create triangle from emotions
        // Get Pos jea/amb
        Vector3 JeaAmbPos = JealousyPos.position + ((AmbitionPos.position - JealousyPos.position) * (((float)stats.Ambition/stats.Jealousy)/2));
        //Debug.Log(JeaAmbPos);
        // Get Pos jea/pride
        Vector3 JeaPriPos = JealousyPos.position + ((PridePos.position - JealousyPos.position) * (((float)stats.Pride/stats.Jealousy)/2));
        //Debug.Log(JeaPriPos);
        // Get pos amb/pride
        Vector3 AmbPriPos = AmbitionPos.position + ((PridePos.position - AmbitionPos.position) * (((float)stats.Pride/stats.Ambition)/2));
        //Debug.Log(AmbPriPos);

        /// Find centroid of triangle
        DotPos.position = new Vector3(
            (JeaAmbPos.x + JeaPriPos.x + AmbPriPos.x)/3,
            (JeaAmbPos.y + JeaPriPos.y + AmbPriPos.y)/3,
            0
        );
    }
}

[AttributeUsage(AttributeTargets.Method)]
public class ExposeMethodInEditor : Attribute
{

}
