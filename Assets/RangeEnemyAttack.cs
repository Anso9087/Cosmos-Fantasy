using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyAttack : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb2D;
    public GameObject bullet;
    public float distanceToShoot;
    public float distanceToStop;
    public float fireRate;
    private float timeToFire;
    public Transform firingPoint;
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
        if (target != null){
            if (Vector2.Distance(target.position, transform.position) <= distanceToShoot){
                Shoot();
            }
        
        }
    }

    private void Shoot(){
        if (timeToFire<= 0f){
            Instantiate(bullet, firingPoint.position, Quaternion.identity);
            timeToFire = fireRate;
        } else {
            timeToFire -= Time.deltaTime;
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
