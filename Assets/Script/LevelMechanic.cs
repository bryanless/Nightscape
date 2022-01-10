using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMechanic : MonoBehaviour
{
    public int enemyCount;
    public int timer;
    private int enemyAmount;
    private int enemyDead;
    public int level;
    public GameObject slime;
    public GameObject player;
    public ShopMenu shopMenu;
    public GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        level = 1;

        shopMenu.isOpen = false;
        enemyDead = 0;
        enemyAmount = 0;

        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy(slime);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnEnemy(GameObject enemyType)
    {
        int positionX = Random.Range(-10, 10);
        int positionY = Random.Range(-10, 10);
        Vector2 enemyPosition = new Vector2(player.transform.position.x + positionX, player.transform.position.y + positionY);
        var enemy = Instantiate(enemyType, enemyPosition, Quaternion.identity);
        enemy.GetComponent<EnemyReceiveDamage>().levelMechanic = this;
        enemyAmount++;
    }

    public void addDeath()
    {
        enemyDead++;

        endLevel();
    }

    public void startLevel()
    {
        level += 1;

        enemyDead = 0;
        enemyAmount = 0;
        enemyCount += 2;

        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy(slime);
        }

        for (int i = 0; i < 3; i++)
        {
            //float minPositionX = -23f;
            //float maxPositionX = 23f;
            //float minPositionY = -13f;
            //float maxPositionY = 13;


            Vector2 itemPosition = new Vector2(Random.Range(-23, 24), Random.Range(-13, 13));
            Instantiate(items[0], itemPosition, Quaternion.identity);
        }

        PlayerStats.playerStats.levelUp();
    }

    void endLevel()
    {
        if (enemyAmount <= enemyDead)
        {
            // Level complete
            // Buka panel, timer
            shopMenu.OpenShop(timer);
        }
    }
}
