using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    // Start is called before the first frame update

    public Button button;
    public int price;
    public int minDamage;
    public int maxDamage;
    public float projectileCooldown;
    public enum CoinType { coins_gold, coins_silver, coins_bronze };
    public CoinType coinType;
    public bool isBuyValid;
    public bool isSold;
    public int gunIndex;
    public PlayerHands playerHands;
    public ShopMenu shopMenu;

    void Start()
    {
        isSold = false;
        playerHands = GameObject.FindGameObjectWithTag("playerHand").GetComponent<PlayerHands>();
        shopMenu = GameObject.FindGameObjectWithTag("shopMenu").GetComponent<ShopMenu>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuyItem()
    {

        if (PlayerStats.playerStats.CheckGun(this))
        {
            playerHands.ChangeGun(this, gunIndex);

            button.interactable = false;
            shopMenu.CloseShop();
        }
        else
        {
            PlayerStats.playerStats.MinusCoins(this);
            if (isBuyValid)
            {
                playerHands.ChangeGun(this, gunIndex);
                PlayerStats.playerStats.gunList.Add(this);
                isSold = true;
                button.interactable = false;
                shopMenu.CloseShop();
            }
        }

        // set active sold out
    }
}
