using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour
{
    float speed = 4f;

    [SerializeField]
    Rigidbody2D rb;

    int health = 3;

    int current_health = 1;
    // Update is called once per frame
    private void Update()
    {
        //move bullet
        rb.velocity = Vector2.left * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //destroy bullet when hits the wall
        if (collision.gameObject.CompareTag("bullet"))
        {
            if (current_health == health)
            {
                Destroy(gameObject);
            }
            else
            {
                current_health += 1;
            }
        }
        else if(collision.gameObject.CompareTag("left_wall"))
        {
            Destroy(gameObject);
        }
    }
}
