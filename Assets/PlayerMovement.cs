using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    SpriteRenderer playerSpriteRenderer;
    Vector2 movementInput;
    Rigidbody2D player2D;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    // Start is called before the first frame update
    void Start()
    {
        player2D = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
   
    private void FixedUpdate() {
        if(movementInput != Vector2.zero){
            int count = player2D.Cast(movementInput, movementFilter, castCollisions, 
                moveSpeed * Time.fixedDeltaTime + collisionOffset);
            
            if(count == 0){
                player2D.MovePosition(player2D.position + movementInput * moveSpeed * Time.fixedDeltaTime);
            }
        }
        if(movementInput.x<0){
            playerSpriteRenderer.flipX = true;
        }
        else if(movementInput.x>0){
            playerSpriteRenderer.flipX = false;
        }

    }

    void OnMove(InputValue movementValue){
        movementInput = movementValue.Get<Vector2>();
    }
    
}
