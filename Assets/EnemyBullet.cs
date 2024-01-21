using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float force;
    public float lifeTime;
    private Rigidbody2D enemyBullet;
    public float damage;
    public Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyBullet = GetComponent<Rigidbody2D>();
        Vector3 direction = player.position - transform.position;
        Vector3 rotation = transform.position - player.position;
        enemyBullet.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot =Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<playerHealth>().health -= damage;
            Destroy(gameObject);
        }
    }

}
