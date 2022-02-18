using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed;
    [SerializeField] float _collisionCooldown = 0.5f;
    [SerializeField] ParticleSystem _impactEffect;

    [SerializeField] UnityEvent _onTouch;

    BulletPool _bulletPool;
    public void SetBulletPool(BulletPool _pool) => _bulletPool = _pool;

    public Vector3 Direction { get; private set; }
    public int Power { get; private set; }
    float LaunchTime { get; set; }

    internal void Init(BulletPool _pool) => _bulletPool = _pool;

    internal void ResetBullet(Vector3 pos, Vector3 vector3, int power)
    {
        transform.position = pos;
        Direction = vector3;
        Power = power;
        LaunchTime = Time.fixedTime;
    }

    void FixedUpdate()
    {
        _rb.MovePosition((transform.position + (Direction.normalized * _speed)));
    }
    
    void LateUpdate()
    {
        transform.rotation = EntityRotation.AimPositionToZRotation(transform.position, transform.position + Direction);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.fixedTime < LaunchTime + _collisionCooldown) return;

        if (collision.TryGetComponent<IHealth>(out var health)) { health.TakeDamage(Power); }
        else if (collision.TryGetComponent<ITouchable>(out var touchable)) { touchable.Touch(Power); }
        else { return; }

        _onTouch?.Invoke();

        _bulletPool.DeactivateBullet(this);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.fixedTime < LaunchTime + _collisionCooldown) return;

        if (collision.collider.TryGetComponent<IHealth>(out var health)) { health.TakeDamage(Power); }
        else if (collision.collider.TryGetComponent<ITouchable>(out var touchable)) { touchable.Touch(Power); }
        else { return; }

        _onTouch?.Invoke();

        _bulletPool.DeactivateBullet(this);
    }

    public void SetImpactEffect()
    {
        ParticleSystem _ = Instantiate(_impactEffect, transform.position, Quaternion.identity);
        _.transform.parent = null;
    }
}
