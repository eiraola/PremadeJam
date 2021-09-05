using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public int enemyCount = 0;
    public int howMuchEnemies = 5;
    int spawnersUsed = 0;
    public GameObject dog;
    public GameObject[] dogSpawners;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnemyDied()
    {
        enemyCount++;
        if((enemyCount % howMuchEnemies) == 0)
        {
            spwanDog();
        }

    }
    public void spwanDog()
    {
        Instantiate(dog, dogSpawners[0].transform.position, Quaternion.identity);
    }
}
