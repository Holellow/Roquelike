﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestEnemyShooting : MonoBehaviour
{
    private GameObject player;
    
    public GameObject projectile;

    public float minDamage;

    public float maxDamage;

    public float projectileForce;

    public float cooldown;
    
    
    private void Start()
    {
        StartCoroutine(ShootPlayer());
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    IEnumerator ShootPlayer()
    {
       
            yield return new WaitForSeconds(cooldown);
            if(player != null)
            {
                
                GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
                Vector2 myPos = transform.position;
                Vector2 targetPos = player.transform.position;
                Vector2 direction = (targetPos - myPos).normalized;
                spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
                spell.GetComponent<TestEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);
                StartCoroutine(ShootPlayer());
            }
    }
}
