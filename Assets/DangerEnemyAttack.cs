using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerEnemyAttack : MonoBehaviour
{
    public Transform target;
    public float enemyHealth;
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
   private void Update()
    {
        if (!target){
            getarget();
        }
        if (enemyHealth <= 0){
            Destroy(gameObject);
        }
    }

    private void getarget(){
        if ( GameObject.FindGameObjectWithTag("Player")){
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (enemyHealth <= 0){
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            Destroy(other.gameObject);
            target = null;
        } else if (other.gameObject.CompareTag("Bullet")){
            enemyHealth -= other.gameObject.GetComponent<Bullet>().damage;
            Destroy(other.gameObject);
            
        }
    }
}
