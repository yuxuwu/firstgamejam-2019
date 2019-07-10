using UnityEngine;

public class StatsTracker : MonoBehaviour
{
    public int Jealousy {get; private set;}
    public int Pride {get; private set;}
    public int Ambition {get; private set;}

    public void AddJealousy(int val)
    {
        Jealousy += val;
    }

    public void SubJealousy(int val)
    {
        Jealousy -= val;
    }

    public void AddPride(int val)
    {
        Pride += val;
    }

    public void SubPride(int val)
    {
        Pride -= val;
    }

    public void AddAmbition(int val)
    {
        Ambition += val;
    }

    public void SubAmbition(int val)
    {
        Ambition -= val;
    }
}
