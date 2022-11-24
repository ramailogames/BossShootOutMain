using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed, life, damage;
    Rigidbody2D rb;
    [SerializeField] GameObject destroyVfx;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject, life);
        rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().TakeHealth(damage);
            Instantiate(destroyVfx, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


}
