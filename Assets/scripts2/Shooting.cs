using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePOs;
    public GameObject bullet;
    public Transform weapon;
    private float timeToFire;
    public static float fireRate = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        fireRate = PlayerPrefs.GetFloat("fireRate");
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePOs = mainCam.ScreenToWorldPoint(Input.mousePosition); //set the mouse position based on the main camera input
        Vector3 rotation = mousePOs - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ); // rotate to correct value

        if(Input.GetMouseButton(0) && !AbilityPause.isPause && !Clear.isPause){ //left click the mouse button to shoot
            Shoot();
        }
    }

    private void Shoot(){
        if (timeToFire<= 0f){ // put sound effect here
            Instantiate(bullet, weapon.position, weapon.transform.rotation); //spawn a bullet object and shoot from the firing point position and rotate the bullet towards player
            timeToFire = fireRate; //setting the firing rate
        } else {
            timeToFire -= Time.deltaTime;
        }
    }
}
