using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    private float maxHealth = 100f;
    private float currentHealth;

    private float amountOfHealthToAdd = 10f; //amount of health to regain 
    private float amountOfHealthToLoose = 0.01f; //amount of health to loose each frame

    public static HealthBar instance;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && PlayerProperties.amountFood > 0)
        {
            AddHealth(amountOfHealthToAdd);
        }

        if (currentHealth > 0)
            LooseHealth(amountOfHealthToLoose);
    }

    public void AddHealth(float amount) //amount = amount of health to add
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += amount;
            healthBar.value = currentHealth;
            PlayerProperties.amountFood--;
        }

    }

    public void LooseHealth(float amount) //amount = amount of health to loose
    {
        currentHealth -= amount;
        healthBar.value = currentHealth;
    }

}
