using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Health _health;

    public Health Health => _health;

    void Start()
    {
        _health.OnDeath += Die;   // fait ici et pas dans l'inspecteur pour ne pas donner la possibilité au GDs de changer le Die qui est géré par nous, et pour eviter qu'un autre prog appel la fonction Die d'autre part
    }

    void OnDestroy()
    {
        _health.OnDeath -= Die;
    }

    void Die() => Destroy(gameObject);
}
