using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    public List<string> items;

    //  début des déclaration e variable
    public static Player instance;
    public int currentHealth;
    public int maxHealth = 8;

    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    private bool isFacingRight = false;

    [SerializeField] private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    [SerializeField] private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    private bool IsWallSliding;
    [SerializeField] private float wallSlidingSpeed = 2f;

    [SerializeField] private float groundDrag;
    [SerializeField] private float aireDrag;
    [SerializeField] private float wallDrag;

    private bool IsWallJumping;
    private float wallJumperDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(8f, 16f);



    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // fin de déclaration de variable
    private void Awake() // fonction qui instancie la classe "Player"
    {
        instance = this;  
    }

    private void Start() //fonction qui rend égale la vie du joueur a son nombre de pv max
    {
        currentHealth = maxHealth;

        items = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded()) // fais fonctioné le coyote jump
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;


        }

        if (Input.GetButtonDown("Jump")) // fais fonctioné le jump buffering
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }


        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)// créé un ecteur qui influence la puissance du saut
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            jumpBufferCounter = 0;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) // permet de sauter
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }

        WallSlide();//appele de la fonction nommée
        WallJump();//appele de la fonction nommée
        DragControl();//appele de la fonction nommée


        if (!IsWallJumping)
        {
            Flip();//appelle de la fonction nommée

        }
    }

    private void FixedUpdate()
    {
        if (!IsWallJumping)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }

    private bool IsGrounded() //detecte le sol
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool IsWalled() // detecte les murs
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()// permet de slide sur les murs
    {
        if (IsWalled() && !IsGrounded() && horizontal != 0f)
        {
            Debug.Log("ici wall");
            IsWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            IsWallSliding = false;
        }
    }

    private void WallJump()// permet de walljump
    {
        if (IsWallSliding)
        {
            IsWallJumping = false;
            wallJumperDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            IsWallJumping = true;
            rb.velocity = new Vector2(wallJumperDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumperDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void DragControl() //permet de modifier la résistance des fortement 
    {

        if (IsGrounded() && !IsWalled())
        {
            rb.drag = groundDrag;
        }
        else if (!IsGrounded() && IsWalled())
        {
            rb.drag = wallDrag;
        }
        else if (!IsGrounded() && !IsWalled())
        {
            rb.drag = aireDrag;
        }
    }

    private void StopWallJumping() // arrte de le walljump
    {
        IsWallJumping = false;
    }
    private void Flip() // retourne le personnge 
    {
        if (!isFacingRight && horizontal < 0f || isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }



    public void TakeDamage(int damage) //prend des dégat (pas fonctionelle)
    {
        if (currentHealth >= 1)
        {
            currentHealth -= damage;
            maxHealth = currentHealth;
            Debug.Log(currentHealth);
        }

    }

    public void Translate(Vector3 v)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"));
        {
            print("we have coollected an item");

            Destroy(collision.gameObject);  
        }
    }
}   
