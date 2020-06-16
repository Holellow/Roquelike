using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyReceiveDamage : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject healthBar;
    public Slider healthBarSlider;
    void Start()
    {
        health = maxHealth;
    }

    public void DealDamage(float damage)
    {
        
        health -= damage;
        healthBar.SetActive(true);
        healthBarSlider.value = CalculateHealthPercentage();
        CheckDeath();
    }

   
    private void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        healthBarSlider.value = CalculateHealthPercentage();
    }

    private void CheckDeath()
    {
        if (health <= 0 )
        {
            Destroy(gameObject); 
        }
    }

    private float CalculateHealthPercentage()
    {
        return health / maxHealth;
    }
}
