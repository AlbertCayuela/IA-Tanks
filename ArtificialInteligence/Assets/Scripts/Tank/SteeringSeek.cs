using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringSeek : MonoBehaviour
{

    public GameObject target;
    public Vector3 movement;
    public float acceleration;
    public Quaternion rotation;
    public bool ret = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Seek();
    }

   public bool Seek()
   {
        ret = true;

        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0f;
        movement = direction.normalized * acceleration;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z);
        rotation = Quaternion.AngleAxis(angle, Vector3.up);
        //print(rotation);

        return ret;
   }
}
