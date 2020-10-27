using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFire : MonoBehaviour
{
    [SerializeField] enemyDamage _enemy = null;

    [Header("Shooting")]
    [SerializeField] Rigidbody _projectile = null;
    [SerializeField] Transform _projSpawn = null;
    [SerializeField] ParticleSystem _weaponShots = null;
    [SerializeField] AudioSource _weaponAudio = null;

    float _reset = 0.5f;

    void Update()
    {
        if (_enemy._followPlayer)
        {
            _reset -= Time.deltaTime;

            if (_reset < 0)
            {
                Shoot();
                _reset = 0.5f;
            }
        }
    }

    void Shoot()
    {
        _weaponShots.Play();
        Rigidbody clone;
        clone = (Rigidbody)Instantiate(_projectile, _projSpawn.position, _projectile.rotation);

        clone.velocity = _projSpawn.TransformDirection(Vector3.forward * 20);

        Debug.Log("Enemy Fired");
        _weaponAudio.Play();
    }
}