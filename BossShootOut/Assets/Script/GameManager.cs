using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("ShootPoints")]
    public Transform[] shootPoints;
    [HideInInspector]public Transform currentShootPoint;


    [Header("Difficulty")]
    public float repeatDelay_Enemy_Shoot, min_repeatDelay_Enemy_Shoot;
    public float increaseDifficultRepeatDelay;

    [Header("Game over")]
    [SerializeField] GameObject gameOver;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InvokeRepeating("IncreaseDifficulty", 20f, increaseDifficultRepeatDelay);
    }

    public void SelectAShootPoint()
    {
        int index = Random.Range(0, shootPoints.Length);
        currentShootPoint = shootPoints[index];
    }

    void IncreaseDifficulty()
    {
        if(repeatDelay_Enemy_Shoot <= min_repeatDelay_Enemy_Shoot)
        {
            return;
        }

        repeatDelay_Enemy_Shoot--;
    }

    public void Invoke_GameOver()
    {
        Invoke("GameOver", 1f);
    }
    void GameOver()
    {
        gameOver.SetActive(true);
    }

}
