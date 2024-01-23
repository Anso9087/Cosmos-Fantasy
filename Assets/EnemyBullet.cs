using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float force;
    public float lifeTime;
    private Rigidbody2D enemyBullet;
    public float damage;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyBullet = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * force * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<playerHealth>().health -= damage;
            Destroy(gameObject);
        }
    }

}
