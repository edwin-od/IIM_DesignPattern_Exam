using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour, IPickable
{
    [SerializeField] UnityEvent _onPickedUp;

    public event UnityAction OnPickedUp { add => _onPickedUp.AddListener(value); remove => _onPickedUp.RemoveListener(value); }

    public void Pickup(PlayerEntity _player)
    {
        _onPickedUp?.Invoke();
        Destroy(gameObject);
    }
}
