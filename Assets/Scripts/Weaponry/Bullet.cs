using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public float time;
    public float distance;
    public float damage;

    Rigidbody2D rb;
    float initialTime;
    Vector3 initialPos;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        initialPos = transform.position;
        initialTime = Time.time;
        rb.velocity = transform.up * speed;
    }

    void FixedUpdate()
    {
        Vector3 dist = (transform.position - initialPos);
        if (dist.magnitude >= distance || Time.time - initialTime >= time)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == this.tag)
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
