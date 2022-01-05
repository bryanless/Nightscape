using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMechanic : MonoBehaviour
{
    public int enemyCount;
    public GameObject slime;
    public GameObject player;
    public ShopMenu shopMenu;

    // Start is called before the first frame update
    void Start()
    {
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
        enemyCount--;

        endLevel();
    }

    public void startLevel(float enemyCount)
    {
        this.enemyCount = 0;
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy(slime);
        }
    }

    void endLevel()
    {
        if (enemyCount <= 0)
        {
            // Level complete
            // Buka panel, timer
            shopMenu.OpenShop(30);
        }
    }
}
