using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerEnemyAttack : MonoBehaviour
{
    public Transform target;
    public float enemyHealth;
    public float damage;
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        getarget(); // set the target to player when the enemy spawn
    }

    // Update is called once per frame
   private void Update()
    {
        if (enemyHealth <= 0){ // when the health of the enemy <= 0, destroy the game object from the scene
            Score.scoreValue += 10;
            KillCount.killValue += 1;
            Destroy(gameObject); 
        }
    }

    private void getarget(){ // set the target to player when the enemy spawn
        if ( GameObject.FindGameObjectWithTag("Player")){
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other){ // when things trigger the collider of the enemy
        if(other.gameObject.CompareTag("Player")){ // when "player" tag trigger the collider of th eenemy
            other.gameObject.GetComponent<playerHealth>().health -= damage; // destroy player object
        } else if (other.gameObject.CompareTag("Bullet")){ // when the player's bullet trigger the collider of the enemy, based on the tag "Bullet"
            enemyHealth -= other.gameObject.GetComponent<Bullet>().damage; // based on the damage that set in the bullet script to hurt enemy
            Destroy(other.gameObject);// after the minus of enemy health, destroy the bullet object
            
        }
    }
}
