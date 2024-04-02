using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D physics;


    // Start is called before the first frame update
    private void Start()
    {
        physics = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        physics.velocity = new Vector2(move * 7f, physics.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            physics.velocity = new Vector2(physics.velocity.x, 14f);
        }
    }
}
