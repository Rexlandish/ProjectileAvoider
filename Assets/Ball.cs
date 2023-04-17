using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Vector2 startPosition;
    public Vector2 acceleration;
    public float time;
    public Vector2 endPosition;

    [SerializeField] Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Execute();
    }

    Vector2 CalculateForce()
    {
        // Calculate X
        float xDisplacement = endPosition.x - startPosition.x;
        float finalX = (xDisplacement - acceleration.x * time * time) / (2 * time);

        // Calculate Y
        float yDisplacement = endPosition.y - startPosition.y;
        float finalY = (yDisplacement - acceleration.y * time * time) / (2 * time);

        return new Vector2(finalX, finalY);
    }

    public void SetData(Vector2 startPosition_, Vector2 endPosition_, Vector2 acceleration_, float time_)
    {
        startPosition = startPosition_;
        endPosition = endPosition_;
        acceleration = acceleration_;
        //rb.gravityScale = acceleration_.y; //-acceleration_.y;
        rb.gravityScale = 0.5f * (acceleration_.y / -9.81f); //-acceleration_.y;
        time = time_;
    }

    public void Execute()
    {
        transform.position = startPosition;
        rb.velocity = Vector2.zero;
        rb.AddForce(CalculateForce(), ForceMode2D.Impulse);
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
