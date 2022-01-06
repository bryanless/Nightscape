using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMechanic : MonoBehaviour
{
    public int enemyCount;
    private int enemyAmount;
    private int enemyDead;
    public GameObject slime;
    public GameObject player;
    public ShopMenu shopMenu;

    // Start is called before the first frame update
    void Start()
    {
        enemyDead = 0;

        for (int i = 0; i < 5; i++)
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
        enemyCount++;
    }

    public void addDeath()
    {
        enemyDead++;

        endLevel();
    }

    public void startLevel()
    {
        enemyDead = 0;
        enemyCount = 0;
        enemyAmount = enemyCount + 2;
        for (int i = 0; i < enemyAmount; i++)
        {
            SpawnEnemy(slime);
        }
    }

    void endLevel()
    {
        if (enemyCount <= enemyDead)
        {
            // Level complete
            // Buka panel, timer
            shopMenu.OpenShop(30);
        }
    }
}
