using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float currentHealth = 100;
    [SerializeField] float maxHealth = 100;
    [SerializeField] HealthBar _bar = null;
    [SerializeField] GameObject _deathPanel = null;

    public void reduceHealth(float amount)
    {
        currentHealth -= amount;
        _bar.SetHealthBar(currentHealth/100);
        Debug.Log(currentHealth);
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
            _deathPanel.SetActive(true);
        }
    }
}
