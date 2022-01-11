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

    // Start is called before the first frame update
    void Start()
    {
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
            case "potion_blue":
                PlayerStats.playerStats.HealCharacter(10);
                break;
            case "potion_red":
                PlayerStats.playerStats.HealCharacter(20);
                break;
            case "potion_green":
                PlayerStats.playerStats.HealCharacter(5);
                break;
            case "food_shrimp":
                PlayerStats.playerStats.HealCharacter(10);
                break;
            case "food_chicken":
                PlayerStats.playerStats.HealCharacter(15);
                break;
            case "food_fish":
                PlayerStats.playerStats.HealCharacter(20);
                break;
            case "food_burger":
                PlayerStats.playerStats.HealCharacter(25);
                break;
            case "food_soup":
                PlayerStats.playerStats.HealCharacter(30);
                break;
            default:
                break;
        }
    }
}
