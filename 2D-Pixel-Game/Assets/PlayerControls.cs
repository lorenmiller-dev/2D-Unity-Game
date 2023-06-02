using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    // 
    Vector2 movementInput;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        // movement not 0, try to move
        if (movementInput != Vector2.zero)
        {
            // Check for possible collisions
            int count =rb.Cast(
                movementInput, // X, Y val between -1 and 1
                movementFilter, // where a collision can occur
                castCollisions, // list of collisions to store
                moveSpeed * Time.fixedDeltaTime + collisionOffset); // amount to cast equal to the movement speed + offset
        }
    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }
}
