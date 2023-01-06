using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveController : MonoBehaviour
{
    public int Health = 100;
    public int maxHealth = 100;

    [SerializeField] bool hasUI = true;
    [Header("UI Controller")]
    public Image HealthBar;

    // Update is called once per frame
    void Update()
    {
        if (HealthBar) HealthBar.fillAmount = Health/100;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
    }

    public void GaimHealth(int amount)
    {
        Health += amount;
        if (Health > maxHealth) Health = maxHealth;
    }
}
