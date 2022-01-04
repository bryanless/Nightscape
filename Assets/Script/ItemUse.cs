using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public int inventoryIndex;

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
        Destroy(gameObject);
        playerInventory.isFull[inventoryIndex] = false;
    }
}
