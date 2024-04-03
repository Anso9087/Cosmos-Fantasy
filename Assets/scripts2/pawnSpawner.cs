using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawnSpawner : MonoBehaviour
{
    public float spawningPerSec;
    [SerializeField] private GameObject[] enemyPrefabType; // provide a better interface to add the type of enemy which will spawn to the array
    private bool ableSpawn = true; //spawning always turn on, until some situation occur which related to the kill count
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
        WaitForSeconds waitSec = new WaitForSeconds(spawningPerSec); // setting the wait how many second to spawn

        while (ableSpawn){
            yield return waitSec;
            int randNum = Random.Range(0, enemyPrefabType.Length); //set up the range based on how many type of enemy prefab putting on the array
            GameObject enemySpawn = enemyPrefabType[randNum]; // randomly set a type of enemy prefab
            Instantiate(enemySpawn, transform.position, Quaternion.identity); // spawn the enemy at the position of the spawner
        }
    }
}
