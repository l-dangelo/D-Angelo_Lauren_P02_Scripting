using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().reduceHealth(10);
            this.GetComponent<ParticleSystem>().Play();
            this.GetComponent<AudioSource>().Play();

            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}