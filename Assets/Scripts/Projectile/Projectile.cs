using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
//private void OnCollisionEnter2D(Collision2D collision);

public class Projectile : MonoBehaviour
{

    public float lifetime;

    [HideInInspector]
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        if (lifetime <= 0)
            lifetime = 2.0f;
        

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, lifetime);
      
 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            Destroy(gameObject);


        if (gameObject.CompareTag("PlayerProjectile"))
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<Enemy>().TakeDamage(1);
                
                Destroy(gameObject);
            }
        }

        if (gameObject.CompareTag("EnemyProjectile") && collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.lives--;
            Destroy(gameObject);
        } 
    }
}



