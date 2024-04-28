using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D physics;

    private BoxCollider2D ground;

    [SerializeField] private LayerMask JumpSurface;

    public bool havedoublejump = false;
    public bool doublejump = false;

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
        float move = Input.GetAxisRaw("Horizontal");
        physics.velocity = new Vector2(move * 7f, physics.velocity.y);

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
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DoubleJump"))
        {
            havedoublejump = true;
        }
    }

    private bool IsOnGround()
    {
        return Physics2D.BoxCast(ground.bounds.center, ground.bounds.size, 0f, Vector2.down, .1f, JumpSurface);
    }
}
