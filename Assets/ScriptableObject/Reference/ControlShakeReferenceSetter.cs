using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlShakeReferenceSetter : MonoBehaviour
{
    [SerializeField] ControlShake _controlShake;
    [SerializeField] ControlShakeReference _controlShakeRef;

    void Awake()
    {
        (_controlShakeRef as IReferenceSetter<ControlShake>).SetInstance(_controlShake);
    }


}
