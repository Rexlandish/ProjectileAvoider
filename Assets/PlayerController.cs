using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Transform groundCheckObject;
    [SerializeField] KeyCode jumpKey;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] LayerMask groundLayerMask;
    
    Rigidbody2D rb;
    float horizontal;
    bool canJump;

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
        rb.velocity = new Vector2(horizontal, rb.velocity.y);

        if (Input.GetKeyDown(jumpKey))
        {
            Jump();
            canJump = false;
        }

        // Check if touched ground
        RaycastHit2D[] hit = Physics2D.RaycastAll(groundCheckObject.position, Vector2.down * 0.1f);
        foreach (RaycastHit2D hitPoint in hit)
        {
            print(hitPoint.transform.name);
            if (hitPoint.transform.gameObject.layer == groundLayerMask.value)
            {
                canJump = true;
            }
        }

        Debug.DrawRay(groundCheckObject.position, Vector2.down * 0.1f);
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
