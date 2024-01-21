using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerEnemyAttack : MonoBehaviour
{
    public Transform target;
   
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
    }

    private void getarget(){
        if ( GameObject.FindGameObjectWithTag("Player")){
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            Destroy(other.gameObject);
            target = null;
        } else if (other.gameObject.CompareTag("Bullet")){
            Destroy(other.gameObject);
            Destroy(gameObject);
            
        }
    }
}
