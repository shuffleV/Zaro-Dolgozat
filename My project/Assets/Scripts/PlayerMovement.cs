using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D physics;

    private BoxCollider2D ground;

    [SerializeField] private LayerMask JumpSurface;
    [SerializeField] private Transform WallCheck;
    [SerializeField] private LayerMask wallLayer;

    private float horizontal;
    private bool isFacingRight = true;

    public bool havedoublejump = false;
    public bool doublejump = false;

    public bool havewalljump = false;

    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;

    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 1f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(8f, 16f);

    public int jumpcount = 0;

    // Start is called before the first frame update
    private void Start()
    {
        physics = GetComponent<Rigidbody2D>();
        ground = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (!isWallJumping)
        {
            physics.velocity = new Vector2(horizontal * 7f, physics.velocity.y);
        }
        

        if (havedoublejump)
        {
            if (IsOnGround() && !Input.GetButton("Jump"))
            {
                doublejump = false;
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (IsOnGround() || doublejump)
                {
                    physics.velocity = new Vector2(physics.velocity.x, 16f);

                    doublejump = !doublejump;
                }
            }

            if (Input.GetButtonUp("Jump") && physics.velocity.y > 0f)
            {
                physics.velocity = new Vector2(physics.velocity.x, physics.velocity.y * 0.5f);
            }

            if (havewalljump)
            {
                WallSlide();
                WallJump();

                if (!isWallJumping)
                {
                    Flip();
                }
            }

            Flip();
        }
        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (IsOnGround())
                {
                    physics.velocity = new Vector2(physics.velocity.x, 16f);
                }
            }

            if (Input.GetButtonUp("Jump") && physics.velocity.y > 0f)
            {
                physics.velocity = new Vector2(physics.velocity.x, physics.velocity.y * 0.5f);
            }

            if (havewalljump)
            {
                WallSlide();
                WallJump();
            }

            Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DoubleJump"))
        {
            havedoublejump = true;
        }
        if (collision.gameObject.CompareTag("WallJump"))
        {
            havewalljump = true;
        }
    }

    private bool IsOnGround()
    {
        return Physics2D.BoxCast(ground.bounds.center, ground.bounds.size, 0f, Vector2.down, .1f, JumpSurface);
    }

    private bool IsOnWall()
    {
        return Physics2D.OverlapCircle(WallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (IsOnWall() && !IsOnGround() && horizontal != 0f)
        {
            isWallSliding = true;
            physics.velocity = new Vector2(physics.velocity.x, Mathf.Clamp(physics.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJump));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter>0f)
        {
            isWallJumping = true;
            physics.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJump), wallJumpingDuration);
        }
    }
    private void StopWallJump()
    {
        isWallJumping = false;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal<0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
