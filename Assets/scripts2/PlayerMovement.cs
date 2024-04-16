using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem; //using the Unity Iput system package

public class PlayerMovement : MonoBehaviour
{
    public static float speed = 2f;
    public float collisionPickUp = 0.05f; //value of how fast to pick up collision
    public ContactFilter2D movementFilter;
    private SpriteRenderer playerSpriteRenderer;
    private Vector2 movementInput;
    private Rigidbody2D player2D;

    List<RaycastHit2D> doCollisions = new List<RaycastHit2D>(); //help to check the movement is valid before the moving, check is there any collision
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));
        speed = PlayerPrefs.GetFloat("speed");
        player2D = GetComponent<Rigidbody2D>(); // give rigidbody2D reference
        playerSpriteRenderer = GetComponent<SpriteRenderer>(); // give sprite renderer reference
    }

    // Update is called once per frame
   
    private void FixedUpdate() {
        if(movementInput != Vector2.zero){ //if player is trying to move
            int count = player2D.Cast(movementInput, movementFilter, doCollisions, 
                speed * Time.fixedDeltaTime + collisionPickUp);
            
            if(count == 0){
                player2D.MovePosition(player2D.position + movementInput * speed * Time.fixedDeltaTime); //move in a consistent speed in consistent frame
            }
        }
        if(movementInput.x<0){ //flipping based on the movement input of player
            playerSpriteRenderer.flipX = true; 
        }else if(movementInput.x>0){
            playerSpriteRenderer.flipX = false;
        }

    }

    private void OnMove(InputValue movementValue){ //get the input value
        movementInput = movementValue.Get<Vector2>();
    }
    
}
