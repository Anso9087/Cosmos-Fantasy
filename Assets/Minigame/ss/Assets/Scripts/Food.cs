using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Food : MonoBehaviour
{
    public static Food instance; // get instance

    public Collider2D foodArea; // get food spawn area
    private Snake snake; // get small snake

    private void Awake() { snake = FindObjectOfType<Snake>(); } // find snake
    private void Start() { RandomizePosition(); } // random food spawn

    public void RandomizePosition()
    {   Bounds bounds = foodArea.bounds; // find food spawn bounds

       
        float x = Random.Range(bounds.min.x, bounds.max.x); // can use Mathf.RoundToInt() to make it blockful
        float y = Random.Range(bounds.min.y, bounds.max.y); // random pos inside the bounds

        while (snake.Occupies((int) x, (int)y)) { // if snake here // food can't spawn in the snake
            x++; if (x > bounds.max.x) { x = bounds.min.x; y++; if (y > bounds.max.y) { y = bounds.min.y; } }// can use Mathf.RoundToInt()
        }
        transform.position = new Vector2(x, y); // pos
    }

    
    private void OnTriggerEnter2D(Collider2D other){ RandomizePosition(); } // randomized position
}
