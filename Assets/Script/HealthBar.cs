using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] PlayerReference _player;
    [SerializeField] Slider _healthBar;

    private void Start() 
    { 
        _player.Instance.Health.OnDamage += UpdateHealthBar; 
        _player.Instance.Health.OnHeal += UpdateHealthBar; 
    }

    private void OnDestroy() 
    { 
        _player.Instance.Health.OnDamage -= UpdateHealthBar; 
        _player.Instance.Health.OnHeal -= UpdateHealthBar; 
    }

    void UpdateHealthBar(int _) => _healthBar.value = (float)_player.Instance.Health.CurrentHealth / _player.Instance.Health.MaxHealth;
}
