using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;

    public GameObject player;
    public Text healthText;
    public Slider healthSlider;

    public float health;
    public float maxHealth;

    public int coins_gold, coins_silver, coins_bronze;
    public Text goldCoinsValueText, silverCoinsValueText, bronzeCoinsValueText;

    void Awake()
    {
        //function for not losing data after changing scene
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

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        setHealthUI();
        setCoinsUI();
    }

    private void setCoinsUI()
    {
        goldCoinsValueText.text = "0";
        silverCoinsValueText.text = "0";
        bronzeCoinsValueText.text = "0";
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
        setHealthUI();
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverHeal();
        setHealthUI();
    }

    private void setHealthUI()
    {
        healthSlider.value = CalculateHealthPercentage();
        healthText.text = Mathf.Ceil(health).ToString() + " / " + Mathf.Ceil(maxHealth).ToString();
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
            health = 0;
            Destroy(player);
        }
    }
    float CalculateHealthPercentage()
    {
        return (health / maxHealth);
    }

    public void AddCoins(CoinsPickup coins)
    {
        if (coins.currentObject == CoinsPickup.PickupObject.coins_gold)
        {
            coins_gold += coins.pickupQuantity;
            goldCoinsValueText.text = coins_gold.ToString();
        }
        else if (coins.currentObject == CoinsPickup.PickupObject.coins_silver)
        {
            coins_silver += coins.pickupQuantity;
            silverCoinsValueText.text = coins_silver.ToString();
        }
        else if (coins.currentObject == CoinsPickup.PickupObject.coins_bronze)
        {
            coins_bronze += coins.pickupQuantity;
            bronzeCoinsValueText.text = coins_bronze.ToString();
        }






    }

    // Update is called once per frame
    void Update()
    {

    }
}
