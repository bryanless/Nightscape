using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReceiveDamage : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public LevelMechanic levelMechanic;
    private int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
    }

    private void CheckOverHeal()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void CheckDeath()
    {
        if(health <= 0)
        {
            levelMechanic.addDeath();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
