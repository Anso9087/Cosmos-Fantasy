using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerChase : MonoBehaviour
{
    public Transform player;
    private SpriteRenderer dangerEnemy;
    public float speed;
    public float distanceBetween;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        this.dangerEnemy = this.GetComponent<SpriteRenderer>();
        getarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null){
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            if (distance<distanceBetween){
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed*Time.deltaTime);
                this.dangerEnemy.flipX = player.transform.position.x < this.transform.position.x;
            }

        }
        

    }
    private void getarget(){
        if ( GameObject.FindGameObjectWithTag("Player")){
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
    }
}
