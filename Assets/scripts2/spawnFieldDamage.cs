using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFieldDamage : MonoBehaviour
{
  
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
         Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other){ // when the player enter the field, player would be damaged
        if (other.gameObject.CompareTag("Player")){
            playerHealth.health -= damage;
        }
    }
}
