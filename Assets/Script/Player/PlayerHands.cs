using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHands : MonoBehaviour
{
    public GameObject playerHand;
    public Sprite[] handList;
    public GameObject[] gunList;

    // Start is called before the first frame update
    void Start()
    {
        //player.GetComponent<SpriteRenderer>().sprite = handList[0];
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeGun(int gunIndex)
    {
        playerHand.GetComponent<SpriteRenderer>().sprite = handList[gunIndex];
    }
}
