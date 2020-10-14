using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject target; //enemy tank
    public GameObject turret; //tank turret

    public float v = 30f; //bullet valocity
    public float g = Physics.gravity.y;  //gravity
    public float x; //distance from tank to target
    public float y; //enemy height
    public float angle_tan; //angle before doing Mathf.atan
    public float angle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Vector3.Distance(target.transform.position, turret.transform.position);

        y = target.transform.position.y;

        float square_part = (v * v * v * v) - g * (g * (x * x) + 2 * y * (v * v));
        float squared_res = (v * v) + Mathf.Sqrt(square_part);
        angle_tan = squared_res / (g * x);
        angle = Mathf.Rad2Deg * Mathf.Atan(angle_tan);

        //rotate the turret
        turret.transform.LookAt(target.transform);
        turret.transform.Rotate(turret.transform.right, angle, Space.World);
         
    }
}
