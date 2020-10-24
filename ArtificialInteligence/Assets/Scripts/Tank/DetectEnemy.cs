using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
 
    public GameObject enemy;   //enemy tank
    //public GameObject turret; //tank turret
    public float range_to_detect; //range where enemy is gonna be detected
    public float distance_to_enemy = 0f; //distance from the tank to the enemy tank
    public bool enemy_detected = false; //bool to check if the tank detected the enemy tank

 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //calculate distance from tank to enemy tank
        distance_to_enemy = Vector3.Distance(enemy.transform.position, transform.position);

        //if the enemy tank is in the detecting range --> enemy detected
        if (distance_to_enemy <= range_to_detect)
        {
            enemy_detected = true;
            //turret.transform.LookAt(enemy.transform);
        }
           
    }
}
