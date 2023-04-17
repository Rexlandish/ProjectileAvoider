using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Transform startPosition;
    public Vector2 acceleration;
    public float time;
    public Transform endPosition;

    [SerializeField] Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Execute();
    }

    Vector2 CalculateForce()
    {
        // Calculate X
        float xDisplacement = endPosition.position.x - startPosition.position.x;
        float finalX = (xDisplacement - acceleration.x * time * time) / (2 * time);

        // Calculate Y
        float yDisplacement = endPosition.position.y - startPosition.position.y;
        float finalY = (yDisplacement - acceleration.y * time * time) / (2 * time);

        return new Vector2(finalX, finalY);
    }

    public void SetData(Transform startPosition_, Transform endPosition_, Vector2 acceleration_, float time_)
    {
        startPosition = startPosition_;
        endPosition = endPosition_;
        acceleration = acceleration_ * Physics2D.gravity.y;
        rb.gravityScale = -acceleration_.y;
        time = time_;
    }

    public void Execute()
    {
        transform.position = startPosition.position;
        rb.velocity = Vector2.zero;
        rb.AddForce(CalculateForce(), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
