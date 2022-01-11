using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    private PlayerInventory playerInventory;
    public GameObject itemButton;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            for (int i = 0; i < playerInventory.slots.Length; i++)
            {
                if (playerInventory.isFull[i])
                {
                    if (playerInventory.items[i] == itemButton)
                    {
                        playerInventory.itemAmount[i]++;
                        //itemButton.GetComponent<ItemUse>().itemAmountText.text = playerInventory.itemAmount[i].ToString();
                        Destroy(gameObject);
                        break;
                    }
                }
                else
                {
                    playerInventory.isFull[i] = true;
                    playerInventory.itemAmount[i]++;
                    playerInventory.items[i] = itemButton;
                    GameObject item = Instantiate(itemButton, playerInventory.slots[i].transform, false);
                    item.GetComponent<ItemUse>().inventoryIndex = i;

                    GameObject itemAmount = Instantiate(itemAmountText, playerInventory.slots[i].transform, false);
                    itemAmount.GetComponent<ItemAmount>().itemAmountText = itemAmount;
                    item.GetComponent<ItemUse>().itemAmountText = itemAmount;

                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
