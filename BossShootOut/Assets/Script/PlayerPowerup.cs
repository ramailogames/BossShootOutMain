using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerup : MonoBehaviour
{
    [SerializeField] GameObject homingProjectilePrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(homingProjectilePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
