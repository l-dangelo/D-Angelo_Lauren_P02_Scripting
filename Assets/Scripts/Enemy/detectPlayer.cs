using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectPlayer : MonoBehaviour
{
    [SerializeField] GameObject _attachedEnemy = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _attachedEnemy.GetComponent<enemyDamage>()._followPlayer = true;
        }
    }
}
