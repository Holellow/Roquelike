﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
   public static PlayerStats playerStats;
   
   public float health;
   public float maxHealth;
   
   public GameObject player;
   
   public Text healthText;
   public Slider healthSlider;
   public Slider manaSlider;
   
   
   private void Start()
   {
      health = maxHealth;
      healthSlider.value = 1;
      healthText.text = Mathf.Ceil(health) + "/" + Mathf.Ceil(maxHealth);
   }

   void Awake()
   {
      if (playerStats != null)
      {
         Destroy(playerStats);
      }
      else
      {
         playerStats = this;
      }
      
      DontDestroyOnLoad(this);
   }
   public void DealDamage(float damage)
   {
      health -= damage;
      CheckDeath();
      healthSlider.value = CalculateHealthPercentage();
      healthText.text = Mathf.Ceil(health) + "/" + Mathf.Ceil(maxHealth);
   }

   public void HealCharacter(float heal)
   {
      health += heal;
      CheckOverheal();
      healthSlider.value = CalculateHealthPercentage();
      healthText.text = Mathf.Ceil(health) + "/" + Mathf.Ceil(maxHealth);
   }
   private void CheckOverheal()
   {
      if (health > maxHealth)
      {
         health = maxHealth;
      }
   }

   
   private void CheckDeath()
   {
      if (health <= 0)
      {
         health = 0;
         Destroy(player);
      }
   }

   float CalculateHealthPercentage()
   {
      return health / maxHealth;
   }
}
