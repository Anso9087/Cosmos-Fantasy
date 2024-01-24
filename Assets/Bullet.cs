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
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position -mousePos;
        bulletBody.velocity = new Vector2(direction.x, direction.y).normalized * shootingSpeed; //shoot at the correct direction with shooting speed
        float rot =Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90); //totate the bullet to the correct position
        Destroy(gameObject, lifeTime); //destroy bullet when the life time is 0
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}