using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponFire : MonoBehaviour
{
    [SerializeField] ParticleSystem weaponFlash = null;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            weaponFlash.Play();
            Debug.Log("firing");
        }
    }
}
