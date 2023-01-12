using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameObject explosionEffect;
    public GameObject bullet;
    public GameObject Player;
    public GameObject DeathThing;
    public GameObject FinishThing;
    public static bool finish = false;
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
        if (collision.collider.CompareTag("Floor"))
        {
            Debug.Log("floor");
            jumpcount = 0;
        }

        if (collision.collider.CompareTag("Finish"))
        {
            Player.SetActive(false);
            FinishThing.SetActive(true);
            finish = true;
        }

        if (collision.collider.CompareTag("Enemy"))
        {
            DeathThing.SetActive(true);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        transform.Translate(transform.right * dirX * speed * Time.deltaTime);
    }

    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && jumpcount != 2)
        {
            Debug.Log("jump");
            //set the Y velocity to 0
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            jumpcount++;
        }

        if (dirX == -1 || dirX == 1)
        {
            facingDirX = dirX;

            if (Input.GetButtonDown("Fire1"))
            {
                GameObject BulletFire = Instantiate(bullet, transform.position, Quaternion.identity);
                BulletFire.GetComponent<Bullet>().dirX = facingDirX;
            }
        }
    }
}
