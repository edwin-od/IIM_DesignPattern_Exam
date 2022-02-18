using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEntity : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] ControlShakeReference _shakeReference;

    public Health Health => _health;

    void Start()
    {
        _health.OnDeath += Die;   // fait ici et pas dans l'inspecteur pour ne pas donner la possibilité au GDs de changer le Die qui est géré par nous, et pour eviter qu'un autre prog appel la fonction Die d'autre part
        _health.OnDamage += DamageTaken;
    }

    void OnDestroy()
    {
        _health.OnDeath -= Die;
        _health.OnDamage -= DamageTaken;
    }

    void Die() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    void DamageTaken(int _)
    {
        _shakeReference.Instance.LaunchScreenShake();
    }
}


