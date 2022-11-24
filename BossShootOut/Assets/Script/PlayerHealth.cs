using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    [SerializeField] GameObject[] hearts;
    int currentHeartNumber = 2;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    void TakeHeart()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[currentHeartNumber].SetActive(false);
        }

        currentHeartNumber--;
    }
    public void TakeHealth(float amount)
    {

        currentHealth -= amount;
      
        Debug.Log("Player Health = " + currentHealth);

        if (currentHealth <= 0)
        {
            //gameover
            GameManager.instance.Invoke_GameOver();
            Destroy(gameObject);
        }

        TakeHeart();

    }
}
