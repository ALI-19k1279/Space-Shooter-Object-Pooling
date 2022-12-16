using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceship : MonoBehaviour
{
    //for moving
    private float vertical;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    float speed;

    //for shooting
    [SerializeField]
    private GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        //get input
        vertical = Input.GetAxisRaw("Vertical");

        //shoot
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void Fire()
    {
        //create bullet
         //create bullet
        Vector3 bulletPosition = new Vector3(transform.position.x + 1, transform.position.y, -1);

        //Instantiate(bulletPrefab, bulletPosition, Quaternion.Euler(0, 0, -90));

        //Get a bullet from the Pool
        GameObject bullet = ObjectPool.instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = bulletPosition;
            bullet.transform.rotation = Quaternion.Euler(0, 0, -90);
            bullet.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        //move
        rb.velocity = new Vector2(0, vertical * speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //destroy bullet when hits the wall
        if (collision.gameObject.CompareTag("rock"))
        {
            Destroy(gameObject);
        }
    }
}