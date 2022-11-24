using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [HideInInspector] public float playedTime = 0;

    private void OnEnable()
    {
        playedTime = 0;
    }

    private void Start()
    {
        playedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playedTime += Time.deltaTime;
    }
}
