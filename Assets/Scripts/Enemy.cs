using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 5f;

    float dirX = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * dirX * speed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * dirX, 0.6f);

        Debug.DrawRay(transform.position, transform.right * 0.6f * dirX, Color.blue);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.CompareTag("Wall"))
            {
                dirX *= -1f;
            }

            if (hit.collider.CompareTag("Player"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
