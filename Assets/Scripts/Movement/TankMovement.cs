using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{

 

    //speed of tank
    public float tankSpeed = 10f;
    //player rigid body
    Rigidbody2D tankRB;
    Vector2 movement;
    float movementSmoothing = 10f;
    Quaternion previousRotation;
  
    // Start is called before the first frame update
    void Awake()
    {
       
        tankRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }

    void move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement = new Vector2(x, y);
        tankRB.velocity = movement.normalized * tankSpeed;
       
       //rotating player into direction it's looking at
       if(movement.x != 0 || movement.y != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, movement), movementSmoothing * Time.fixedDeltaTime);
            previousRotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, movement), movementSmoothing * Time.fixedDeltaTime);
        }
        else
        {
            transform.rotation = previousRotation;
        }
   
    }

}
