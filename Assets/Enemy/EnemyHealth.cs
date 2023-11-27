using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyHealth : MonoBehaviour
{
    int enemyHealth;
    [SerializeField] int startHealth = 5;
    [Tooltip ("Adds specified amount to enemy health when enemy dies")]
    [SerializeField] int difficultyRamp = 1;

    Enemy enemy;

    void Start() 
    {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable() 
    {
        enemyHealth = startHealth;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        enemyHealth--;
        if (enemyHealth < 1)
        {
            KillEnemy();
            startHealth += difficultyRamp;
            enemy.RewardGold();
        }
    }

    void KillEnemy()
    {
        gameObject.SetActive(false);
    }
}
