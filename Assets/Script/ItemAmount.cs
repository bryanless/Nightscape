using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAmount : MonoBehaviour
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
        if (playerInventory.itemAmount[inventoryIndex] > 1)
        {
            itemAmountText.GetComponent<Text>().text = playerInventory.itemAmount[inventoryIndex].ToString();
        }
        else
        {
            itemAmountText.GetComponent<Text>().text = "";
        }
    }
}
