using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Check Surrounding")]
    [SerializeField] Transform rightCheckWallPos;
    [SerializeField] float checkWallRadius;
    [SerializeField] LayerMask whatIsWall;
    bool isTouchingWall;

    [Header("Movement")]
    [SerializeField] float movementSpeed;
    Vector2 velocityWorkSpace;
    int facingDirection = 1;

    [Header("Components")]
    Rigidbody2D rb;

    [Header("Enemy Bullets")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform[] shootPositions;
    [SerializeField] float start_ShootingDealy, repeat_ShootingDelay;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        InvokeRepeating("Shoot", start_ShootingDealy, GameManager.instance.repeatDelay_Enemy_Shoot);
    }
    public void CheckSurroundings()
    {
        isTouchingWall = Physics2D.OverlapCircle(rightCheckWallPos.position, checkWallRadius, whatIsWall);

        if (isTouchingWall)
        {
            Flip();
        }

    }

    private void Update()
    {
        CheckSurroundings();
    }

    private void FixedUpdate()
    {
        SetVelocity(movementSpeed);
    }


    void SetVelocity(float speed)
    {
        rb.velocity = new Vector2(facingDirection * speed * Time.deltaTime, rb.velocity.y);
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0, 180, 0);
    }

    void Shoot()
    {

        StartCoroutine(ShootEnum());
     
    }

    IEnumerator ShootEnum()
    {
        int index = Random.Range(0, shootPositions.Length);
        Instantiate(bullet, shootPositions[index].position, Quaternion.identity);
        yield return new WaitForSeconds(.5f);
        index = Random.Range(0, shootPositions.Length);
        Instantiate(bullet, shootPositions[index].position, Quaternion.identity);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(rightCheckWallPos.position, checkWallRadius);
    }
}
