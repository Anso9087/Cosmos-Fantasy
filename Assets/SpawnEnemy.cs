using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float spawningRate;
    [SerializeField] private GameObject[] enemyPrefabs; // provide a better interface to add the type of enemy which will spawn to the array
    private bool canSpawn = true; //spawning always turn on, until some situation occur which related to the kill count
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawner()); //start the spawning
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator spawner(){
        WaitForSeconds wait = new WaitForSeconds(spawningRate); // setting the wait how many second to spawn

        while (canSpawn){
            yield return wait;
            int randNum = Random.Range(0, enemyPrefabs.Length); //set up the range based on how many type of enemy prefab putting on the array
            GameObject enemySpawn = enemyPrefabs[randNum]; // randomly set a type of enemy prefab
            Instantiate(enemySpawn, transform.position, Quaternion.identity); // spawn the enemy at the position of the spawner
        }
    }
}
