using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCollision : MonoBehaviour
{

    BoxCollider2D collider;
    float health;
    // Start is called before the first frame update
    void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfDead();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

       if(collision.gameObject.name == "Enemy Decoy")
        {
            health -= 10;
        } 
    }

    void CheckIfDead()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
