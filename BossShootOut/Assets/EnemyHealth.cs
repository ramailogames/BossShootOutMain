using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    

    [Header("Health")]
    public float maxHealth;
    float currentHealth;
    public GameObject hpbar;
    [SerializeField] Material white, def;
    SpriteRenderer sr;
    private void Awake()
    {
         sr = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        currentHealth = maxHealth;
        def = sr.material;
    }

    private void Update()
    {

    }

    public void TakeHealth(float amount)
    {
       
        currentHealth -= amount;
        sr.material = white;
        hpbar.transform.localScale = new Vector2(currentHealth / maxHealth, hpbar.transform.localScale.y);
        Invoke("ResetMat", 0.15f);
    }

    void ResetMat()
    {
        sr.material = def;
    }
}
