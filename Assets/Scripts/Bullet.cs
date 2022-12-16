using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private int health = 0;
    public GameObject Explosion;
    public float speed = 15f;
    public float lifeTime = 20;
    public float dirX = 1f;
    private AudioSource audiosource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall");
            dirX *= -1f;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject, 1f);
            dirX *= 0f;
            Animation();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            health += 1;
            if (collision.gameObject.CompareTag("Player") && health == 2)
            {
                Destroy(collision.gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        ShootingSound();
        Destroy(gameObject, lifeTime);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * dirX * speed * Time.deltaTime);
    }

    private void Animation()
    {
        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void ShootingSound()
    {
        audiosource.Play();
    }
}
