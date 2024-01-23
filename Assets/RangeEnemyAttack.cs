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
    public Transform weapon;
    public Transform firingPoint;
    public float enemyHealth;
    // Start is called before the first frame update
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        getarget();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!target){
            getarget();
        }
        if (target != null){
            Vector3 rotation = target.position - weapon.transform.position;
            float rotZ =Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            weapon.transform.rotation = Quaternion.Euler(0, 0, rotZ);
            if (Vector2.Distance(target.position, transform.position) <= distanceToShoot){
                Shoot();
            }
        
        }
        if (enemyHealth <= 0){
            Destroy(gameObject);
        }
    }

    private void Shoot(){
        if (timeToFire<= 0f){
            Instantiate(bullet, firingPoint.position, firingPoint.transform.rotation);
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
        if (other.gameObject.CompareTag("Bullet")){
            enemyHealth -= other.gameObject.GetComponent<Bullet>().damage;
            Destroy(other.gameObject);
        }
    }    
}
