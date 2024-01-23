using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float spawningRate;
    [SerializeField] private GameObject[] enemyPrefabs;
    public int spawnCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator spawner(){
        WaitForSeconds wait = new WaitForSeconds(spawningRate);

        if (spawnCount <3){
            while (spawnCount < 3){
                yield return wait;
                int rand = Random.Range(0, enemyPrefabs.Length);
                GameObject enemyToSpawn = enemyPrefabs[rand];
                Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
                spawnCount ++;
        }
        
        }
    }
}
