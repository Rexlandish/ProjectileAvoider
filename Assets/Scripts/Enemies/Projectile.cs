using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] Transform target;
    [SerializeField] bool homing = false;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {

        //transform.rotation = Quaternion.Euler(0f, 0f, rotationAmount);
        //if (homing) transform.rotation = Quaternion.Euler(0f, 0f, Vector2.SignedAngle(transform.position, target.position));
        transform.up = target.position - transform.position;
        print(transform.eulerAngles.z);
        transform.position += new Vector3(Mathf.Cos(transform.rotation.eulerAngles.z), Mathf.Sin(transform.rotation.eulerAngles.z), 0f) * Time.deltaTime;
        //transform.position += transform.right * 10f * Time.deltaTime;


        //transform.position += Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }


}
