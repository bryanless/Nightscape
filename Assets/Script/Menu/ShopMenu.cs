using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public GameObject shopPanel;
    public GameTimer gameTimer;
    public LevelMechanic levelMechanic;
    public bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    public void CloseShop()
    {
        isOpen = false;
        shopPanel.SetActive(false);
        levelMechanic.startLevel();
    }
}
