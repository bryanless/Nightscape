using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    // Start is called before the first frame update

    public Button button;
    public int price;
    public enum CoinType { coins_gold, coins_silver, coins_bronze };
    public CoinType coinType;
    public bool isBuyValid;
    public bool isSold;

    void Start()
    {
        isSold = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyItem()
    {
        PlayerStats.playerStats.MinusCoins(this);

        if (isBuyValid)
        {
            //PlayerGun.playerGun.AddGun(this);
            isSold = true;
            button.interactable = false;
            // set active sold out
        }
    }
}
