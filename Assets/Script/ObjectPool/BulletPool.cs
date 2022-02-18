using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] Bullet _prefab;
    [SerializeField] int _maxSize;
    [SerializeField] int _minSize;

    List<Bullet> _activePool;
    List<Bullet> _dormantPool;

    #region Editor
    private void Reset()
    {
        _maxSize = 1;
        _minSize = 0;
    }
    private void OnValidate()
    {
        _maxSize = Mathf.Max(_minSize, _maxSize);

        _minSize = Mathf.Max(_minSize, 1);
        _minSize = Mathf.Min(_minSize, _maxSize);
    }
    #endregion

    private void Awake() => Init();

    void Init() 
    {
        _activePool = new List<Bullet>();
        _dormantPool = new List<Bullet>();

        for (int i = 0; i < _minSize; i++) { CreateBullet(); } 
    }

    public void ActivateBullet(Vector3 pos, Vector3 vector3, int power)
    {
        if (_dormantPool.Count <= 0) 
        {
            while (_activePool.Count >= _maxSize) DestroyBullet(_activePool[0]);     // Destroy the oldest instances
            CreateBullet(); 
        }

        Bullet instance = _dormantPool[0];
        _dormantPool.RemoveAt(0);
        _activePool.Add(instance);
        instance.ResetBullet(pos, vector3, power);
        instance.gameObject.SetActive(true);
    }

    public void DeactivateBullet(Bullet _instance)
    {
        if (_dormantPool.Count + _activePool.Count > _minSize) { DestroyBullet(_instance); return; }

        if (_activePool.Contains(_instance)) 
        { 
            _activePool.Remove(_instance);
            _dormantPool.Add(_instance);
        }

        _instance.gameObject.SetActive(false);
    }

    private void CreateBullet() 
    {
        Bullet instance = Instantiate(_prefab, transform);
        instance.Init(this);
        _dormantPool.Add(instance);
        instance.gameObject.SetActive(false);
    }

    private void DestroyBullet(Bullet _instance)
    {
        if (_dormantPool.Contains(_instance)) _dormantPool.Remove(_instance);
        else if (_activePool.Contains(_instance)) _activePool.Remove(_instance);
        Destroy(_instance.gameObject);
    }
}
