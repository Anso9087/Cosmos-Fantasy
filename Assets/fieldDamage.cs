using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fieldDamage : MonoBehaviour
{

    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other){ // when the player enter the field, player would be damaged
        if (other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<playerHealth>().health -= damage;
        }
    }
}
