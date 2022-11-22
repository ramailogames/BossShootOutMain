using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movementInputDirection;

    private bool isFacingRight = true;
    private bool isMoving = false;
    private bool isGrounded;

    [Header("Components")]
    Rigidbody2D rb;
    Animator anim;

    [Header("Movement Settings")]
    public float MovementSpeed = 10.0f;
    public float jumpForce = 16f;

    [Header("Ground Check")]
    public Transform groundCheckPos;
    public float groundRadius;
    public LayerMask whatIsGround;

    [Header("Jump")]
    bool canJump = true;

    [Header("Shoot")]
    public bool isShooting = false;
    [SerializeField] Transform shootPos;
    [SerializeField] GameObject projectilePrefab;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckMovementDirection();
        UpdateAnimations();
        CheckSurroundings();
        CheckIfCanJump();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        
    }

    private void CheckMovementDirection()
    {
        if(isFacingRight && movementInputDirection < 0)
        {
            Flip();
        }
        else if( !isFacingRight && movementInputDirection >0)
        {
            Flip();
        }

        if(Mathf.Abs(movementInputDirection) > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isShooting)
            {
                return; // return if player is shooting
            }
            Jump();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    } 

    private void ApplyMovement()
    {
        if (isShooting)
        {
            return; // return if player is shooting
        }
        rb.velocity = new Vector2(MovementSpeed * movementInputDirection, rb.velocity.y);

       
      
    }

    private void UpdateAnimations()
    {
        anim.SetFloat("speed",Mathf.Abs(movementInputDirection));

        if (isGrounded)
        {
            anim.SetBool("jump", false);
            return;
        }

        anim.SetBool("jump", true);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180.0f, 0f);
    }

    void Jump()
    {
        if (!canJump)
        {
            return;
        }
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPos.position, groundRadius, whatIsGround);

    }

    public void Shoot()
    {
        // check if can shoot
        if (!isGrounded)
        {
            return;
        }

        //shot
        isShooting = true;
        rb.velocity = Vector2.Lerp(new Vector2(rb.velocity.x, rb.velocity.y), new Vector2(0, 0), Time.deltaTime);
        anim.SetTrigger("shoot");

    }

    public void InstanstiateProjectile()
    {
        Instantiate(projectilePrefab, shootPos.position, Quaternion.identity);
    }
    public void ResetShoot()
    {
        isShooting = false;
        anim.ResetTrigger("shoot");
    }
        

    void CheckIfCanJump()
    {
        if (isGrounded && rb.velocity.y <= 0)
        {
            canJump = true;
            return;
        }

        canJump = false;
    }

    private void OnDrawGizmos()
    {
        if (isGrounded)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheckPos.position, groundRadius);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheckPos.position, groundRadius);
        }
     
    }

}
