using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3BossChase : MonoBehaviour
{
    public Transform player;
    private SpriteRenderer dangerEnemy;
    public float speed;
    public float distanceBetween;
    private float distance;
    private bool isDashing;
    private bool canDash = true;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        this.dangerEnemy = this.GetComponent<SpriteRenderer>(); // give the reference of the sprite renderer
        getarget(); // get target when spawn, to prevent the enemy spawn and go to the direction of the player prefab
        StartCoroutine(Dash());
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null){ // prevent the null reference error
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            if (distance<distanceBetween && canDash){
                if(isDashing){
                    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, Time.deltaTime*speed*10);
                }
            }else{
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed*Time.deltaTime); // move to the direction of the player
                this.dangerEnemy.flipX = player.transform.position.x < this.transform.position.x; // flip to face the player
            }

        }
    }  

    private void getarget(){ // set the target to player when the enemy spawn
        if ( GameObject.FindGameObjectWithTag("Player")){ // based on th e tag to find player
            player = GameObject.FindGameObjectWithTag("Player").transform; // update the player transform as the scene object, not prefeab
        }
        
    }
    private IEnumerator Dash(){
        while (canDash){
            yield return new WaitForSeconds(0.5f);
            isDashing = true;
            yield return new WaitForSeconds(0.15f);
            canDash = false;
            isDashing = false;
            yield return new WaitForSeconds(3f);
            canDash = true;
        }
    }
}
