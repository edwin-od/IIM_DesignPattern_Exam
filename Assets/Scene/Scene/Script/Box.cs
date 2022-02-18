using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Box : MonoBehaviour, ITouchable
{
    [SerializeField] List<Potion> _potionDrops = new List<Potion>();
    [SerializeField, Range(0, 1)] float _dropProbability = 0.33f;

    [SerializeField] UnityEvent _onTouched;

    public event UnityAction OnTouched { add => _onTouched.AddListener(value); remove => _onTouched.RemoveListener(value); }

    void ITouchable.Touch(int power)
    {
        _onTouched?.Invoke();

        if (Random.Range(0.0f, 1.0f) <= _dropProbability) 
        { 
            Potion _instance = Instantiate(_potionDrops[Random.Range(0, _potionDrops.Count)], transform.position, Quaternion.identity);
            _instance.transform.parent = null;
        }

        Destroy(gameObject);
    }
}
