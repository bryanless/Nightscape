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
    public Text shieldText;
    public Slider shieldSlider;

    public float health;
    public float maxHealth;

    public float shield;
    public float maxShield;

    private bool checkRegenIsActive;

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
        maxHealth = 50;
        health = maxHealth;
        maxShield = Mathf.Ceil(maxHealth / 3f);
        shield = maxShield;
        checkRegenIsActive = false;
        setHealthUI();
        setShieldUI();
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
        float shieldDamage = (damage / 4);
        shield -= shieldDamage;

        if (shield < 0)
        {
            shield = 0;
            health -= damage;
        }

        if (shield < maxShield && !checkRegenIsActive)
        {
            checkRegenIsActive = true;
            StartCoroutine(RegenShield());
        }

        CheckDeath();
        setHealthUI();
        setShieldUI();
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverHeal();
        setHealthUI();
    }

    private IEnumerator RegenShield()
    {
        yield return new WaitForSeconds(10);

        while (shield < maxShield)
        {
            shield += 1;
            CheckOverShield();
            setShieldUI();
            yield return new WaitForSeconds(5);
        }

        checkRegenIsActive = false;

    }

    public void setHealthUI()
    {
        healthSlider.value = CalculateHealthPercentage();
        healthText.text = Mathf.Ceil(health).ToString() + " / " + Mathf.Ceil(maxHealth).ToString();
    }

    public void setShieldUI()
    {
        shieldSlider.value = CalculateShieldPercentage();
        shieldText.text = Mathf.Ceil(shield).ToString() + " / " + Mathf.Ceil(maxShield).ToString();
    }

    private void CheckOverHeal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void CheckOverShield()
    {
        if (shield > maxShield)
        {
            shield = maxShield;
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

    float CalculateShieldPercentage()
    {
        return (shield / maxShield);
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

    public void MinusCoins(ShopItem shopItem)
    {
        shopItem.isBuyValid = false;

        if (shopItem.coinType == ShopItem.CoinType.coins_gold)
        {
            if (coins_gold >= shopItem.price)
            {
                coins_gold -= shopItem.price;
                goldCoinsValueText.text = coins_gold.ToString();
                shopItem.isBuyValid = true;
            }
        }
        else if (shopItem.coinType == ShopItem.CoinType.coins_silver)
        {
            if (coins_silver >= shopItem.price)
            {
                coins_silver -= shopItem.price;
                silverCoinsValueText.text = coins_silver.ToString();
                shopItem.isBuyValid = true;
            }
        }
        else if (shopItem.coinType == ShopItem.CoinType.coins_bronze)
        {
            if (coins_bronze >= shopItem.price)
            {
                coins_bronze -= shopItem.price;
                bronzeCoinsValueText.text = coins_bronze.ToString();
                shopItem.isBuyValid = true;
            }
        }
    }

    public void levelUp()
    {
        float maxHealthTemp = maxHealth;
        maxHealth = (maxHealthTemp * (105f / 100f));
        HealCharacter(maxHealthTemp * (5f/ 100f));
        setHealthUI();

        maxShield = Mathf.Ceil(maxHealth / 3f);
        shield = maxShield;

        setShieldUI();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
