using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageVolume : MonoBehaviour
{
    [SerializeField] int _damageAmount = 1;
    [SerializeField] float _damageInterval = 0.5f;

    bool _isCollided = false;
    PlayerHealth _collided = null;

    private void OnTriggerEnter(Collider other)
    {
        _isCollided = true;
        _collided = other.gameObject.GetComponent<PlayerHealth>();
    }

    private void OnTriggerExit(Collider other)
    {
        _isCollided = false;
    }

    private void Update()
    {
        if (_isCollided)
        {
            float timer = 1f;

            dealDamage();
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                dealDamage();
                timer = _damageInterval;
            }
        }
    }

    void dealDamage()
    {
        _collided.reduceHealth(_damageAmount);
        _collided.kill();
    }
}
