using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeChase : MonoBehaviour
{
    public Transform player;
    public float speed;
    public float distanceBetween;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        getarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null){
            distance = Vector2.Distance(transform.position, player.position);
            Vector2 direction = player.position - transform.position;

            if (distance>=distanceBetween){
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed*Time.deltaTime);
            }

        }
        

    }
    private void getarget(){
        if ( GameObject.FindGameObjectWithTag("Player")){
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
    }
}