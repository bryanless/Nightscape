using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUse : MonoBehaviour
{
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
        playerInventory.itemAmount[inventoryIndex]--;
        itemAmountText.GetComponent<Text>().text = playerInventory.itemAmount[inventoryIndex].ToString();

        if (playerInventory.itemAmount[inventoryIndex] == 0)
        {
            Destroy(gameObject);
            Destroy(itemAmountText);
            playerInventory.isFull[inventoryIndex] = false;
        }
    }
}
