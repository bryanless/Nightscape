using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyReceiveDamage : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public LevelMechanic levelMechanic;
    private int enemyCount;

    public GameObject healthBar;
    public Slider healthBarSlider;

    public GameObject lootDrop1;
    public GameObject lootDrop2;
    public GameObject lootDrop3;
    private int lootDropCount1, lootDropCount2, lootDropCount3;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void DealDamage(float damage)
    {
        healthBar.SetActive(true);
        health -= damage;
        CheckDeath();
        healthBarSlider.value = CalculateHealthPercentage();
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverHeal();
        healthBarSlider.value = CalculateHealthPercentage();
    }

    private void CheckOverHeal()
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
            levelMechanic.addDeath();
            Destroy(gameObject);

            lootDropCount1 = UnityEngine.Random.Range(-8, 2);
            lootDropCount2 = UnityEngine.Random.Range(-3, 2);
            lootDropCount3 = UnityEngine.Random.Range(1, 3);

            if(lootDropCount1 < 0)
            {
                lootDropCount1 = 0;
            }
            if (lootDropCount2 < 0)
            {
                lootDropCount2 = 0;
            }

            for (int i = 0; i < lootDropCount1; i++)
            {
                Vector2 newPosition = new Vector2(transform.position.x + UnityEngine.Random.Range(-2, 5), transform.position.y + UnityEngine.Random.Range(-2, 5));
                Instantiate(lootDrop1, newPosition, Quaternion.identity);
            }
            for (int i = 0; i < lootDropCount2; i++)
            {
                Vector2 newPosition = new Vector2(transform.position.x + UnityEngine.Random.Range(-2, 5), transform.position.y + UnityEngine.Random.Range(-2, 5));
                Instantiate(lootDrop2, newPosition, Quaternion.identity);
            }
            for (int i = 0; i < lootDropCount3; i++)
            {
                Vector2 newPosition = new Vector2(transform.position.x + UnityEngine.Random.Range(-2, 5), transform.position.y + UnityEngine.Random.Range(-2, 5));
                Instantiate(lootDrop3, newPosition, Quaternion.identity);
            }


        }
    }

    private float CalculateHealthPercentage()
    {
        return (health / maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
