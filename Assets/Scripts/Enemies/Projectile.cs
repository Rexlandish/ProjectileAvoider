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
        if (homing) StartCoroutine(TurnOffHoming());
    }

    // Update is called once per frame
    void Update()
    {

        if (homing) transform.rotation = Quaternion.Euler(0f, 0f, AngleBetweenPoints(transform.position, target.position));
        //if (homing) transform.rotation = Quaternion.Euler(0f, 0f, Vector2.SignedAngle(transform.position, target.position));
        //transform.up = target.position - transform.position;
        //print(transform.eulerAngles.z);
        //transform.position += new Vector3(Mathf.Cos(transform.rotation.eulerAngles.z), Mathf.Sin(transform.rotation.eulerAngles.z), 0f) * Time.deltaTime;
        //transform.position += transform.right * 10f * Time.deltaTime;
        //rb.MovePosition();
        rb.MovePosition(transform.position + -transform.right * moveSpeed * Time.deltaTime * 10f);


        //transform.position += Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    IEnumerator TurnOffHoming()
    {
        yield return new WaitForSeconds(2f);
        homing = false;
    }


}
