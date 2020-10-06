using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image _bar = null;

    public void SetHealthBar(float amount)
    {
        _bar.fillAmount = amount;
    }
}