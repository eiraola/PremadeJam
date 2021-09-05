using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public int enemyCount = 5;
    public GameObject Alien;
    public float offset = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("AlienCountSpawn");
    }

    // Update is called once per frame
    void Update()
    {
       offset = Random.Range(-10.5f, 10.0f);
    }
    public void Spawn()
    {
        AlienScript alien = Instantiate(Alien,transform.position, Quaternion.identity).GetComponent<AlienScript>();
        //alien.SetOffset(offset);
        enemyCount--;
        if(enemyCount == 0)
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }
    }
    IEnumerator AlienCountSpawn()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(0.1f);
            Spawn();


        }
    }
}
