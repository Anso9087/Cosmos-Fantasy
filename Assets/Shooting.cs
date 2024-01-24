using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePOs;
    public GameObject bullet;
    public Transform weapon;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePOs = mainCam.ScreenToWorldPoint(Input.mousePosition); //set the mouse position based on the main camera input
        Vector3 rotation = mousePOs - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ); // rotate to correct value

        if(!canFire){
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring){
                canFire = true;
                timer = 0;
            }
        }

        if(Input.GetMouseButton(0) && canFire){ //left clicl the mouse button to shoot
            canFire =false;
            Instantiate(bullet, weapon.position, Quaternion.identity); //spawn the object at the fire point and shoot
        }
    }
}
