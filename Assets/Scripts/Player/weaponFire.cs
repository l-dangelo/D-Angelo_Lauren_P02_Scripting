using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponFire : MonoBehaviour
{
    [SerializeField] ParticleSystem weaponFlash = null;
    [SerializeField] FireWeapon _player = null;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !_player._shieldState)
        {
            weaponFlash.Play();
            Debug.Log("firing");
        }
    }
}
