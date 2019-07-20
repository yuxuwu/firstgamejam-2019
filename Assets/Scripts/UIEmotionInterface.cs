using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEmotionInterface : MonoBehaviour
{
    Transform JealousyPos = null;
    Transform AmbitionPos = null;
    Transform PridePos = null;
    Transform DotPos = null;

    Material JealousyMat = null;
    Material AmbitionMat = null;
    Material PrideMat = null;
    Material DotMat = null;

    StatsManager stats = null;

    Vector3 OriginPos;

    public class TempVal {
        public enum Emotion {Jealousy, Ambition, Pride};

        public Emotion emotion;
        public int val;

        public TempVal(Emotion emotion, int val)
        {
            this.emotion = emotion;
            this.val = val;
        }
    };

    public class TempValComparer : IComparer<TempVal>
    {
        public int Compare(TempVal val1, TempVal val2)
        {
            if (val1.val == val2.val)
            {
                return 0;
            }
            if (val1.val < val2.val)
            {
                return -1;
            }
            return 1;
        }
    }


    void Start()
    {
        Transform emotion_ui = GameObject.Find("Character/Emotion UI").transform;
        stats = GameObject.Find("Managers").GetComponent<StatsManager>();

        JealousyPos = emotion_ui.Find("Jealousy").transform;
        PridePos = emotion_ui.Find("Pride").transform;
        AmbitionPos = emotion_ui.Find("Ambition").transform;
        DotPos = emotion_ui.Find("Dot").transform;

        JealousyMat = emotion_ui.Find("Jealousy").GetComponent<Renderer>().material;
        PrideMat = emotion_ui.Find("Pride").GetComponent<Renderer>().material;
        AmbitionMat = emotion_ui.Find("Ambition").GetComponent<Renderer>().material;
        DotMat = emotion_ui.Find("Dot").GetComponent<Renderer>().material;



        OriginPos = DotPos.position;

        Debug.Log(OriginPos);
    }

    [ExposeMethodInEditor]
    public void RecalcDotPos()
    {
        Vector3 pos = OriginPos;
        TempVal[] array = new TempVal[3];
        TempValComparer temp = new TempValComparer();

        array[0] = new TempVal(TempVal.Emotion.Jealousy, stats.Jealousy);
        array[1] = new TempVal(TempVal.Emotion.Pride, stats.Pride);
        array[2] = new TempVal(TempVal.Emotion.Ambition, stats.Ambition);

        Array.Sort(array, temp);

        for (int i = 0; i < 3; i++)
        {
            if (array[i].emotion == TempVal.Emotion.Jealousy)
            {
                pos += (JealousyPos.position - pos) * ((float)array[i].val/20);
                StartCoroutine(LerpColorTransparency((float)array[i].val/20, JealousyMat));
            }
            else if (array[i].emotion == TempVal.Emotion.Pride)
            {
                pos += (PridePos.position - pos) * ((float)array[i].val/20);
                StartCoroutine(LerpColorTransparency((float)array[i].val/20, PrideMat));
            }
            else if (array[i].emotion == TempVal.Emotion.Ambition)
            {
                pos += (AmbitionPos.position - pos) * ((float)array[i].val/20);
                StartCoroutine(LerpColorTransparency((float)array[i].val/20, AmbitionMat));
            }
        }
        StartCoroutine(LerpDotPos(pos));
    }

    float SinLerpTime(float time)
    {
        return Mathf.Sin(time * Mathf.PI * 0.5f);
    }

    IEnumerator LerpDotPos(Vector3 end)
    {
        float elapsedTime = 0;
        Vector3 start = DotPos.position;
        while (elapsedTime < 1)
        {
            DotPos.position = Vector3.Lerp(start, end, SinLerpTime(elapsedTime/1));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator LerpColorTransparency(float endAlpha, Material mat)
    {
        float elapsedTime = 0;
        float startAlpha = mat.color.a;

        while (elapsedTime < 1)
        {
            mat.color = new Color( 
                mat.color.r,
                mat.color.g,
                mat.color.b,
                Mathf.Lerp(startAlpha, endAlpha, SinLerpTime(elapsedTime/1))
            );
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

}




[AttributeUsage(AttributeTargets.Method)]
public class ExposeMethodInEditor : Attribute
{

}
