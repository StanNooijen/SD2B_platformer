using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private AudioSource audiosource;

    public float speed = 5f;

    float Line = 0.6f;
    float dirX = 1f;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * dirX * speed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * dirX, Line);

        Debug.DrawRay(transform.position, transform.right * Line * dirX, Color.blue);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.CompareTag("Wall") || hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("Finish"))
            {
                Line *= -1f;
                dirX *= -1f;
                transform.Rotate(0, 180, 0);
            }
            if (hit.collider.CompareTag("Player"))
            {
                DeathSound();
            }
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            MenuManager.Score += 1;
            dirX *= 0f;
        }
    }

    private void Delete()
    {
        Destroy(gameObject);
    }

    private void DeathSound()
    {
        audiosource.Play();
    }
}
