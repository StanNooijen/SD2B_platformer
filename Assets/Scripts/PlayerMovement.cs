using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject bullet;
    public GameObject Player;
    Rigidbody2D rb;

    public float speed = 10;
    public float jump = 5;
    public float jumpcount = 0;

    private float facingDirX = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameObject.FindWithTag("Floor"))
        {
            Debug.Log("floor");
            jumpcount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");

        transform.Translate(transform.right * dirX * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && jumpcount != 2)
        {
            Debug.Log("jump");
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            jumpcount++;
        }

        if (dirX == -1 || dirX == 1)
        {
            facingDirX = dirX;
        }

        if (Input.GetButtonDown("Fire1"))
        {
           GameObject BulletFire =  Instantiate(bullet, transform.position, Quaternion.identity);
           BulletFire.GetComponent<Bullet>().dirX = facingDirX;
        }
    }
}
