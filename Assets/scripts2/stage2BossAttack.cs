using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage2BossAttack : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb2D;
    public GameObject bullet;
    public float ableShootDistance;
    public float fireRate;
    private float timeToFire = 360f;
    public Transform weapon; // follow the player direction to rotate
    public Transform firingPoint; // where the bullet fire
    public float enemyHealth;
    // Start is called before the first frame update
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        getarget(); // set the target to player when the enemy spawn
    }

    // Update is called once per frame
    private void Update()
    {
        if (player != null){
            Vector3 rotation = player.position - weapon.transform.position;
            float zRotation =Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg; // fin out the rotation degree
            weapon.transform.rotation = Quaternion.Euler(0, 0, zRotation);
            if (Vector2.Distance(player.position, transform.position) <= ableShootDistance){ //set the enemy can only shoot in certain distance
                Shoot();
            }
        
        }
        if (enemyHealth <= 0){ // when the health of the enemy <= 0, destroy the game object from the scene
            Score.scoreValue += 1000;
            KillCount.killValue += 1;
            Destroy(gameObject);
        }
    }

    private void Shoot(){
        if (timeToFire<= 0f){
            Instantiate(bullet, firingPoint.position, firingPoint.transform.rotation); //spawn a bullet object and shoot from the firing point position and rotate the bullet towards player
            timeToFire = fireRate; //setting the firing rate
        } else {
            timeToFire -= Time.deltaTime;
        }
    }

    private void getarget(){ // set the target to player when the enemy spawn
        if ( GameObject.FindGameObjectWithTag("Player")){
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other){ // when things trigger the collider of the enemy
        if (other.gameObject.CompareTag("Bullet")){ // when the player's bullet trigger the collider of the enemy, based on the tag "Bullet"
            enemyHealth -= other.gameObject.GetComponent<Bullet>().damage; // based on the damage that set in the bullet script to hurt enemy
            Destroy(other.gameObject); // after the minus of enemy health, destroy the bullet object
        }
    }    
}
