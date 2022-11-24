using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] GameObject powerUpPrefab;
    [SerializeField] Transform[] spawningPoints;

    [SerializeField] float startDelay, repeatDealy;


    private void Start()
    {
        InvokeRepeating("SpawnPowerUp", startDelay, repeatDealy);
    }

    void SpawnPowerUp()
    {
        int random = Random.Range(0, spawningPoints.Length);
        Instantiate(powerUpPrefab, spawningPoints[random].position, Quaternion.identity);
    }

   
}
