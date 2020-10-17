using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject target; //enemy tank
    public GameObject turret; //tank turret
    public Rigidbody bullet; //bullet we will shoot

    public float v = 30f; //bullet valocity
    public float g = Physics.gravity.y;  //gravity
    public float x; //distance from tank to target
    public float y; //enemy height
    public float angle_sin; //angle before doing Mathf.atan
    public float angle;

    public float reloading_timer = 2f;
    public bool reloading = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        x = Vector3.Distance(target.transform.position, turret.transform.position);

        y = target.transform.position.y;

        //float square_part = (v * v * v * v) - g * (g * (x * x) + 2 * y * (v * v));
        //float squared_res = (v * v) + Mathf.Sqrt(square_part);
        //angle_tan = squared_res / (g * x);
        //angle = Mathf.Rad2Deg * Mathf.Atan(angle_tan);
        //Debug.Log(angle);

        //angle = Mathf.Pow(Mathf.Sin((g*x)/(v*v)), -1);
        //angle = angle / 2;

        float part1 = Mathf.Asin((g * x) / (v * v));
        angle_sin = part1 / 2;
        angle = Mathf.Asin(angle_sin) * Mathf.Rad2Deg;


        //rotate the turret
        turret.transform.LookAt(target.transform);
        turret.transform.Rotate(turret.transform.right, angle, Space.World);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
        }

        if (reloading)
        {
            // reloading_timer -= Time.deltaTime;
            Reload();
        }
         
    }

    void ShootBullet()
    {
        bullet = Instantiate(bullet, turret.transform.position, Quaternion.identity);
        bullet.transform.LookAt(target.transform);
        bullet.velocity = turret.transform.forward * v;

        reloading = true;
    }
    
    void Reload()
    {
        reloading_timer -= Time.deltaTime;
        if (reloading_timer <= 0)
        {
            reloading = false;
            reloading_timer = 2;
        }
           

    }
}
