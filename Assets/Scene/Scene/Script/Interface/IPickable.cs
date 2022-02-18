using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IPickable
{
    void Pickup(PlayerEntity _player);
}
