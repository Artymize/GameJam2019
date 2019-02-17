using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    private Transform hub;
    private Transform spawn;
    private Transform target;

    private BoxCollider2D hubCollider;

    public float enemySpeed;
    public float stationTime = 10f; // sets how long the enemy needs to stay @Base
    public float timeStayed = 0f; // how long the enemy has been collecting energy

    public bool targetPlayer;
    public bool energyCollected = false;
    public bool stationed = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        hub = GameObject.FindGameObjectWithTag("Hub").GetComponent<Transform>();
        spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Transform>();
        hubCollider = GameObject.FindGameObjectWithTag("Hub").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        setTarget();

        if (!stationed || energyCollected) moveToTarget();
    }

    void setTarget()
    {
        if (energyCollected)
        {
            target = spawn;
        }
        else
        {
            if (targetPlayer)
                target = player;
            else
                target = hub;
        }
    }

    void moveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.fixedDeltaTime);

        Vector2 targetPos = target.position - transform.position;
        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0,0,angle - 90)), 100);
        // other method
        // transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Hub" && !energyCollected)
        {
            targetPlayer = false;
            stationed = true;
            timeStayed += Time.deltaTime;

            if (timeStayed >= stationTime) energyCollected = true;
        }

        stationed = false;
    }
}