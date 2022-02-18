using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour, ITouchable
{
    public void OpenGate()
    {
        Destroy(gameObject);
    }

    void ITouchable.Touch(int power) { }
}
