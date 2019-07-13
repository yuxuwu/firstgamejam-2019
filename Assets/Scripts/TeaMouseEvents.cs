using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaMouseEvents : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D collider)
    {
        Debug.Log("Entered Tea");
    }
}
