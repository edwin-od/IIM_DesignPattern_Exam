using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour, IPickable
{
    virtual public void Pickup(PlayerEntity _player) { Destroy(gameObject); }
}
