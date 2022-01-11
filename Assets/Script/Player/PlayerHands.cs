using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHands : MonoBehaviour
{
    public GameObject player;
    public GameObject playerHand;
    public Sprite[] handList;
    public GameObject[] gunList;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeGun(ShopItem shopItem, int gunIndex)
    {
        playerHand.GetComponent<SpriteRenderer>().sprite = handList[gunIndex];
        player.GetComponent<Projectile>().minDamage = shopItem.minDamage;
        player.GetComponent<Projectile>().maxDamage = shopItem.maxDamage;
        player.GetComponent<Projectile>().projectileCooldown = shopItem.projectileCooldown;
    }
}
