using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    public GameObject EnemyDeath;

    float dirX = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * dirX * speed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * dirX, 0.6f);

        Debug.DrawRay(transform.position, transform.right * 0.6f * dirX, Color.blue);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.CompareTag("Wall") || hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("Finish"))
            {
                dirX *= -1f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            MenuManager.Score += 1;
            dirX *= 0f;
            Animation();
        }
    }

    private void Animation()
    {
        Instantiate(EnemyDeath, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void Delete()
    {
        Destroy(gameObject);
    }

}
