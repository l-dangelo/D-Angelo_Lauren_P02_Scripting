using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyDamage : MonoBehaviour
{
    float _health = 100;
    public bool _followPlayer = false;
    [SerializeField] GameObject _player = null;
    [SerializeField] Level01Controller _levelController = null;

    NavMeshAgent _navMesh;

    private void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_followPlayer)
        {
            followPlayer();
        }
    }

    public void TakeDamage(float takeDamage)
    {
        _health -= takeDamage;

        Debug.Log("health remaining: " + _health);

        if(_health <= 0)
        {
            this.gameObject.SetActive(false);
            _levelController.IncreaseScore(10);
        }
    }

    void followPlayer()
    {
        _navMesh.destination = _player.transform.position;
    }
}