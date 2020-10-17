using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    [SerializeField] Camera _playCamera = null;
    [SerializeField] Transform rayOrigin = null;
    [SerializeField] float _shootDistance = 10;
    [SerializeField] GameObject _hitFeedback = null;
    [SerializeField] float _weaponDamage = 20;
    [SerializeField] LayerMask _hitLayers;


    RaycastHit objectHit;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
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
}