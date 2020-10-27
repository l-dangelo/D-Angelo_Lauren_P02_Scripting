using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float currentHealth = 100;
    [SerializeField] float maxHealth = 100;
    [SerializeField] HealthBar _bar = null;
    [SerializeField] FireWeapon _player = null;
    [SerializeField] AudioSource _takeDamageAudio = null;

    public void reduceHealth(float amount)
    {
        if (_player._shieldState)
        {
            amount = amount / 2;
        }

        currentHealth -= amount;
        _bar.SetHealthBar(currentHealth/100);
        Debug.Log(currentHealth);
        _takeDamageAudio.Play();

        kill();
    }

    public void gainHealth(float amount)
    {
        if(currentHealth + amount > maxHealth)
        {
            currentHealth = maxHealth;
            _bar.SetHealthBar(currentHealth/100);
        }
        else
        {
            currentHealth += amount;
            _bar.SetHealthBar(currentHealth/100);
        }
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }

    public void kill()
    {
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("DeathMenu");
        }
    }
}