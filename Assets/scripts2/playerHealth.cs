using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public static float health = 100f;
    public static float maximumHealth;
    public Image healthBarPlayer;
    void Start()
    {
        health = PlayerPrefs.GetFloat("health");
        maximumHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthBarPlayer.fillAmount = Mathf.Clamp(health / maximumHealth, 0, 1); // affect the filling percentage of the health bar

        if (health <= 0){ // when health <= 0, destroy player
            Destroy(gameObject);

        }
    }
}
