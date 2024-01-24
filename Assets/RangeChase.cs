using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeChase : MonoBehaviour
{
    public Transform player; // player transform
    private SpriteRenderer rangeEnemy; // accessing the sprite renderer of the range enemy
    public float speed;
    public float distanceBetween; // distance between the player and the range enemy
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        this.rangeEnemy = this.GetComponent<SpriteRenderer>(); // give the reference of the sprite renderer
        getarget(); // get target when spawn, to prevent the enemy spawn and go to the direction of the player prefab
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null){ // prevent the null reference error
            distance = Vector2.Distance(transform.position, player.position);
            Vector2 direction = player.position - transform.position;

            if (distance>=distanceBetween){
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed*Time.deltaTime); // move to the direction of the player
                this.rangeEnemy.flipX = player.transform.position.x < this.transform.position.x; // flip to face the player
            }

        }
        

    }
    private void getarget(){ // set the target to player when the enemy spawn
        if ( GameObject.FindGameObjectWithTag("Player")){ // based on th e tag to find player
            player = GameObject.FindGameObjectWithTag("Player").transform; // update the player transform as the scene object, not prefeab
        }
        
    }
}