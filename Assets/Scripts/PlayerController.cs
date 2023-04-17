using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Transform groundCheckObject;
    bool groundCheckEnabled = true;
    [SerializeField] KeyCode jumpKey;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float moveForce = 10f;
    [SerializeField] LayerMask groundLayerMask;
    
    Rigidbody2D rb;
    float horizontal;
    bool canJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        // Get input
        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * moveForce, rb.velocity.y);

        if (Input.GetKey(jumpKey) && canJump)
        {
            Jump();
            canJump = false;
        }

        // Disable ground raycast if moving upwards
        groundCheckEnabled = !(rb.velocity.y > 0.1f);
        

        // Check if touched ground
        if (groundCheckEnabled)
        {
            RaycastHit2D hit = Physics2D.Raycast(groundCheckObject.position, Vector2.down, 0.1f, groundLayerMask);
            print(hit.collider);
            if (hit.collider != null) canJump = true;
        }

        Debug.DrawRay(groundCheckObject.position, Vector2.down * 0.1f);
    }
        
    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
