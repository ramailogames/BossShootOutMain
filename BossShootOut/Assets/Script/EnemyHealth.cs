using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    

    [Header("Health")]
    public float maxHealth;
    float currentHealth;
    public Healthbar healthBar;
    [SerializeField] Material white;
    Material def;
    SpriteRenderer sr;


    private void Awake()
    {
         sr = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        currentHealth = maxHealth;
        def = sr.material;
        healthBar.SetHealth(maxHealth, maxHealth);
    }

    private void Update()
    {

    }

    public void TakeHealth(float amount)
    {
        FindObjectOfType<RamailoGamesScoreManager>().AddScore(1f);
        AudioManagerCS.instance.Play("enemyhit");
        currentHealth -= amount;
        sr.material = white;
        healthBar.SetHealth(currentHealth, maxHealth);

        Invoke("ResetMat", 0.15f);

        if(currentHealth <= 0)
        {
            FindObjectOfType<EnemySpawner>().EnumSpawn();
            Destroy(gameObject);
        }
    }

    void ResetMat()
    {
        sr.material = def;
    }
}
