using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public float lifeTime = 5;
    public float dirX = 1f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Wall"))
        {
            Debug.Log("Wall");
            Destroy(gameObject);
        }

        if (collision.collider.CompareTag("Enemy"))
        {

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
}
