using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D bulletBody;
    public float shootingSpeed; //the shooting speed
    public float lifeTime = 3f; // life time of the bullet, when it is 0, destroy it

    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        bulletBody = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 bulletRotation = transform.position -mousePos;
        Vector3 bulletDirection = mousePos - transform.position;
        bulletBody.velocity = new Vector2(bulletDirection.x, bulletDirection.y).normalized * shootingSpeed; //shoot at the correct direction with shooting speed
        float zRotation =Mathf.Atan2(bulletRotation.y, bulletRotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, zRotation + 90); //rotate the bullet to the correct position
        Destroy(gameObject, lifeTime); //destroy bullet when the life time is 0
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter2D(Collider2D other){ // when things trigger the collider of the enemy
        if (other.gameObject.CompareTag("Block")){ // when the player's bullet trigger the collider of the enemy, based on the tag "Bullet"
            Destroy(gameObject); //  destroy the bullet object if hit block
        }
     }
}