using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    Transform player;
    GameObject tank;
    float smoothing = 5f;
    Vector3 distance;
    Vector3 target;
    // Start is called before the first frame update
    void Awake()
    {
        //Finds tank object and uses its transform
        tank = GameObject.Find("Tank");
        player = tank.transform;

        //sets initial distance
        distance = transform.position - player.position;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        follow();
    }

    void follow()
    {
        //target distance, basically offsets camera from tank
        target = player.position + distance;

        //Moves, or lerps camera to player position
        transform.position = Vector3.Lerp(transform.position, target, smoothing * Time.deltaTime);

    }
}

