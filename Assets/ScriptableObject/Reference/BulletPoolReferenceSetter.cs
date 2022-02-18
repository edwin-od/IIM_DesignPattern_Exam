using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolReferenceSetter : MonoBehaviour
{
    [SerializeField] BulletPool _bulletPool;
    [SerializeField] BulletPoolReference _bulletPoolRef;

    void Awake()
    {
        (_bulletPoolRef as IReferenceSetter<BulletPool>).SetInstance(_bulletPool);
    }
}
