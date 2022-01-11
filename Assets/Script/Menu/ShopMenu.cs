using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public GameObject shopPanel;
    public GameTimer gameTimer;
    public LevelMechanic levelMechanic;
    public bool isOpen;
    public GameObject[] shopItemButton;
    public ShopMechanic shopMechanic;

    private List<int> shownShopItemIndex;
    private List<GameObject> shownShopItem;

    // Start is called before the first frame update
    void Start()
    {
        shownShopItemIndex = new List<int>();
        shownShopItem = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTimer.time <= 0 && isOpen)
        {
            CloseShop();
        }
    }

    public void OpenShop(float openDuration)
    {
        isOpen = true;
        shopPanel.SetActive(true);
        gameTimer.time = openDuration;

        foreach (GameObject item in shopItemButton)
        {
            if (item != null)
            {
                item.GetComponent<Button>().interactable = true;
            }
        }

        //Random
        for (int i = 0; i < 3; i++)
        {
            int shopItemIndex = Random.Range(0, shopItemButton.Length);

            while (true)
            {
                if (shownShopItemIndex.Contains(shopItemIndex))
                {
                    shopItemIndex = Random.Range(0, shopItemButton.Length);
                }
                else
                {
                    shownShopItemIndex.Add(shopItemIndex);
                    break;
                }
            }

            GameObject shopItem = Instantiate(shopItemButton[shopItemIndex], shopMechanic.slots[i].transform, false);
            shownShopItem.Add(shopItem);
        }

        shownShopItemIndex.Clear();
    }

    public void CloseShop()
    {
        if (gameTimer.time > 0)
        {
            gameTimer.time = 0;
        }

        foreach(GameObject item in shownShopItem)
        {
            Destroy(item);
        }

        isOpen = false;
        shopPanel.SetActive(false);
        levelMechanic.startLevel();
    }
}
