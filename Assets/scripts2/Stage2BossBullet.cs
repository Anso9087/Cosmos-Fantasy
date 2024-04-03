using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stage2BossBullet : MonoBehaviour
{
   public float shootingSpeed;
    public float lifeTime;
    private Rigidbody2D enemyBullet;
    public float damage;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyBullet = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime); //destroy bullet when the life time is 0
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * shootingSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){ //the enemy bullet can only trigger with the object with "Player" tag
            playerHealth.health -= damage; // minus player health
            Destroy(gameObject); //destroy the enemy bullet
        }
        if (other.gameObject.CompareTag("Block")){ // when the player's bullet trigger the collider of the enemy, based on the tag "Bullet"
            Destroy(other.gameObject);
            Destroy(gameObject); //  destroy the bullet object if hit block
        }
    }

}
