using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{

    public GameObject Weapon1;
    public GameObject Weapon2;

    AudioSource weap1Sound;
    Transform firePoint;
    int selected;
    int prevSelected;
    public float rate;
    float delay;


    
    void Awake()
    {
        firePoint = transform.Find("PointofFire");
        delay = 1 / rate;
        selected = 1;
        weap1Sound = GetComponent<AudioSource>();

    }

    void Start()
    {
        
    }


    void Update()
    {
        selectWeapon();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shoot();

        }

    }

    void shoot()
    {

        Vector3 firedPos = firePoint.position;
        Quaternion rotation = firePoint.rotation;
        switch (selected)
        {
            case 1:
                Instantiate(Weapon1, firedPos, rotation);
                break;
           case 2:
                Instantiate(Weapon2, firedPos, rotation);
                break;
            default:
                break;
        }

        weap1Sound.Play();
        
    }

    void selectWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Minigun Selected!");
            selected = 1;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Energy Ball Selected!");
            selected = 2;

        }

        
    }
}
