using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUse : MonoBehaviour
{
    public string itemName;
    public PlayerInventory playerInventory;
    public int inventoryIndex;
    public GameObject itemAmountText;
    public GameObject[] items;

    private int healthPotion;

    // Start is called before the first frame update
    void Start()
    {
        healthPotion = 5;
        playerInventory = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use()
    {
        // Remove 1 item from inventory
        playerInventory.itemAmount[inventoryIndex]--;
        itemAmountText.GetComponent<Text>().text = playerInventory.itemAmount[inventoryIndex].ToString();

        // Use item
        UseItem();

        // Remove item if run out of item
        if (playerInventory.itemAmount[inventoryIndex] == 0)
        {
            Destroy(gameObject);
            Destroy(itemAmountText);
            playerInventory.isFull[inventoryIndex] = false;
        }
    }

    void UseItem()
    {
        switch (itemName)
        {
            case "health_potion":
                PlayerStats.playerStats.HealCharacter(healthPotion);
                break;
            default:
                // code block
                break;
        }
    }
}
