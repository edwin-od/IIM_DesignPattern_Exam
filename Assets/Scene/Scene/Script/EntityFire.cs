using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFire : MonoBehaviour
{
    [SerializeField] Transform _spawnPoint;
    [SerializeField] Bullet _bulletPrefab;
    [SerializeField] BulletPoolReference _bulletPool;

    public void FireBullet(int power)
    {
        //var b = Instantiate(_bulletPrefab, _spawnPoint.transform.position, Quaternion.identity, null)
        //    .Init(_spawnPoint.transform.position, _spawnPoint.TransformDirection(Vector3.right), power);

        _bulletPool.Instance.ActivateBullet(_spawnPoint.transform.position, _spawnPoint.TransformDirection(Vector3.right), power);
    }

}
