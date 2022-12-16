using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Explosion;
    public float speed = 15f;
    public float lifeTime = 20;
    public float dirX = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Wall");
            dirX *= -1f;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
          
            dirX *= 0f;
            Animation();
        }
    }

    private void Start()
    {

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
}
