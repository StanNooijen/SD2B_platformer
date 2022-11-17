using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public GameObject bullet;

    private float facingDirX = 1;
    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");

        transform.Translate(transform.right * dirX * speed * Time.deltaTime);

        if(dirX == -1 || dirX == 1)
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
