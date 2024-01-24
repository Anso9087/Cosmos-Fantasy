using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    public float maxHealth;
    public Image healthBar;
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1); // affect the filling percentage of the health bar

        if (health <= 0){ // when health <= 0, destroy player
            Destroy(gameObject);
        }
    }
}
