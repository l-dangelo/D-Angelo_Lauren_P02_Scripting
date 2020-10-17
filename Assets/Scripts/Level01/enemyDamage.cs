using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    float _health = 100;

    public void TakeDamage(float takeDamage)
    {
        _health -= takeDamage;

        Debug.Log("health remaining: " + _health);

        if(_health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    
}
