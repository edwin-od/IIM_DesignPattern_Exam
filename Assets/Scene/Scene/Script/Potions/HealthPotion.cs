using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Potion
{
    [SerializeField] int _healAmount;

    #region Editor
    private void Reset()
    {
        _healAmount = 1;
    }

    private void OnValidate()
    {
        _healAmount = Mathf.Max(0, _healAmount);
    }
    #endregion

    public override void Pickup(PlayerEntity _player)
    {
        _player.Health.Heal(_healAmount);

        base.Pickup(_player); // only Destroy for now
    }
}
