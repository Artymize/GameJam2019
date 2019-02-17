using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashEnemy : MonoBehaviour
{
    float health;
    CircleCollider2D enemyCollider;


    // Start is called before the first frame update
    void Awake()
    {
        enemyCollider = GetComponent<CircleCollider2D>();
        health = 100000;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        checkIfDead();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject projectile = collision.gameObject;
        Debug.Log(projectile.tag);
        switch (projectile.tag)
        {
            case "Minigun":
                Destroy(projectile);
                break;
            case "EnergyBall":
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), projectile.GetComponent<Collider2D>()); 
                break;
            default:
                break;
        }
        health -= projectile.GetComponent<Bullet>().damage;
    }

    void checkIfDead()
    {
        if (health <= 0)
        {
        Destroy(this.gameObject);
        }
    }
   }
