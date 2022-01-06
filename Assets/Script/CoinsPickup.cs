using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPickup : MonoBehaviour
{
    public enum PickupObject { coins_gold, coins_silver, coins_bronze };
    public PickupObject currentObject;
    public int pickupQuantity;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            //if (currentObject == PickupObject.coins_gold)
            //{
            //    PlayerStats.playerStats.coins_gold += pickupQuantity;
            //    Debug.Log(PlayerStats.playerStats.coins_gold);
            //}
            //else if (currentObject == PickupObject.coins_silver)
            //{
            //    PlayerStats.playerStats.coins_silver += pickupQuantity;
            //    Debug.Log(PlayerStats.playerStats.coins_silver);
            //}
            //else if (currentObject == PickupObject.coins_bronze)
            //{
            //    PlayerStats.playerStats.coins_bronze += pickupQuantity;
            //    Debug.Log(PlayerStats.playerStats.coins_bronze);
            //}
            PlayerStats.playerStats.AddCoins(this);
            Destroy(gameObject);

        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
