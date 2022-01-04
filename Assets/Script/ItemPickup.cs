using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private PlayerInventory playerInventory;
    public GameObject itemButton;

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
                if (playerInventory.isFull[i] == false)
                {
                    playerInventory.isFull[i] = true;
                    var item = Instantiate(itemButton, playerInventory.slots[i].transform, false);
                    item.GetComponent<ItemUse>().inventoryIndex = i;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
