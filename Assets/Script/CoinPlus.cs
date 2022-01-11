using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPlus : MonoBehaviour
{
    private int silverConvertRate;
    private int goldConvertRate;

    // Start is called before the first frame update
    void Start()
    {
        silverConvertRate = 100;
        goldConvertRate = 50;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ConvertToSilver()
    {
        if (PlayerStats.playerStats.coins_bronze >= silverConvertRate)
        {
            PlayerStats.playerStats.coins_silver += (PlayerStats.playerStats.coins_bronze / silverConvertRate);
            PlayerStats.playerStats.coins_bronze = (PlayerStats.playerStats.coins_bronze % silverConvertRate);
            PlayerStats.playerStats.silverCoinsValueText.text = PlayerStats.playerStats.coins_silver.ToString();
            PlayerStats.playerStats.bronzeCoinsValueText.text = PlayerStats.playerStats.coins_bronze.ToString();
        }
    }

    public void ConvertToGold()
    {
        if (PlayerStats.playerStats.coins_silver >= goldConvertRate)
        {
            PlayerStats.playerStats.coins_gold += (PlayerStats.playerStats.coins_silver / goldConvertRate);
            PlayerStats.playerStats.coins_silver = (PlayerStats.playerStats.coins_silver % goldConvertRate);
            PlayerStats.playerStats.goldCoinsValueText.text = PlayerStats.playerStats.coins_gold.ToString();
            PlayerStats.playerStats.silverCoinsValueText.text = PlayerStats.playerStats.coins_silver.ToString();
        }
    }
}
