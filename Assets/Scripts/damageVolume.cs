using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageVolume : MonoBehaviour
{
    [SerializeField] int _damageAmount = 1;
    [SerializeField] float _damageInterval = 0.5f;
    [SerializeField] AudioSource _damage = null;

    bool _isCollided = false;
    PlayerHealth _collided = null;

    private void OnTriggerEnter(Collider other)
    {
        _isCollided = true;
        _collided = other.gameObject.GetComponent<PlayerHealth>();
        _damage.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        _isCollided = false;
        _damage.Stop();
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
    }
}