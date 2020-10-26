using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    [SerializeField] GameObject _player = null;

    [Header("Shooting")]    
    [SerializeField] Transform rayOrigin = null;
    [SerializeField] float _shootDistance = 10;
    [SerializeField] GameObject _hitFeedback = null;
    [SerializeField] float _weaponDamage = 20;
    [SerializeField] LayerMask _hitLayers;

    [Header("Shielding")]
    [SerializeField] GameObject _shield = null;
    [SerializeField] AudioSource _shieldAudioUp = null;
    [SerializeField] AudioSource _shieldAudioDown = null;
    public bool _shieldState = false;

    [Header("Zooming")]
    [SerializeField] Camera _playCamera = null;
    [SerializeField] AudioSource _zoomAudioUp = null;
    [SerializeField] AudioSource _zoomAudioDown = null;

    RaycastHit objectHit;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Shield();
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            ShieldDown();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ZoomIn();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            ZoomOut();
        }
    }

    void Shoot()
    {
        Vector3 rayDirect = _playCamera.transform.forward;

        Debug.DrawRay(rayOrigin.position, rayDirect * _shootDistance, Color.red, 1f);

        if(Physics.Raycast(rayOrigin.position, rayDirect, out objectHit, _shootDistance, _hitLayers))
        {
            if (objectHit.transform.tag.Equals("Enemy"))
            {
                Debug.Log("Hit " + objectHit.transform.name);
                _hitFeedback.transform.position = objectHit.point;
                _player.GetComponent<PlayerMovement>().HitActivity();

                enemyDamage shooter = objectHit.transform.gameObject.GetComponent<enemyDamage>();
                if (shooter != null)
                {
                    shooter.TakeDamage(_weaponDamage);
                }
            }
        }
        else
        {
            Debug.Log("Miss");
        }
    }

    void Shield()
    {
        _shield.SetActive(true);
        _shieldState = true;
        _shieldAudioUp.Play();
    }

    void ShieldDown()
    {
        _shield.SetActive(false);
        _shieldState = false;
        _shieldAudioDown.Play();
    }

    void ZoomIn()
    {
        _playCamera.fieldOfView = 30;
        _zoomAudioUp.Play();
    }

    void ZoomOut()
    {
        _playCamera.fieldOfView = 60;
        _zoomAudioDown.Play();
    }
}