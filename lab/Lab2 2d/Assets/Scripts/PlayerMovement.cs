using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpHeight = 5f;
    CapsuleCollider2D capsuleCollider;

    Vector2 movementVector;
    Rigidbody2D rbody;
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }


    void Update()
    {
        Vector2 playerVelocity = new Vector2(movementVector.x * movementSpeed, rbody.velocity.y);
        rbody.velocity = playerVelocity;
    }

    private void OnMove(InputValue value)
    {
        movementVector = value.Get<Vector2>();

    }

    private void OnJump(InputValue value)
    {
        if (!capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (value.isPressed)
        {
            rbody.velocity += new Vector2(0f, jumpHeight);
        }
    }
}
