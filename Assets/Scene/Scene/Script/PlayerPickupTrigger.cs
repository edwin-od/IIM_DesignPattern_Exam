using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupTrigger : MonoBehaviour
{
    [SerializeField] PlayerReference _player;
    [SerializeField] PhysicEvent2D _trigger;

    private void Start()
    {
        _trigger.TriggerEnter2D += _trigger_TriggerEnter2D;
        _trigger.CollisionEnter2D += _trigger_CollisionEnter2D;
    }

    private void OnDestroy()
    {
        _trigger.TriggerEnter2D -= _trigger_TriggerEnter2D;
        _trigger.CollisionEnter2D -= _trigger_CollisionEnter2D;
    }

    private void _trigger_TriggerEnter2D(Collider2D arg0)
    {
        if (arg0.TryGetComponent<IPickable>(out IPickable pickup))
        {
            pickup.Pickup(_player.Instance);
        }
    }

    private void _trigger_CollisionEnter2D(Collision2D arg0)
    {
        if (arg0.collider.TryGetComponent<IPickable>(out IPickable pickup))
        {
            pickup.Pickup(_player.Instance);
        }
    }
}
