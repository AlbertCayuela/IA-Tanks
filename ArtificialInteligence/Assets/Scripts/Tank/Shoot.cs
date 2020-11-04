﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //ENEMY DETECTION VARIABLES
    public float range_to_detect = 20f; //range where enemy can be detected
    public float distance_to_enemy; //actual distance to enemy
    public bool enemy_detected = false;

    public GameObject target; //enemy tank
    public GameObject turret; //tank turret
    public Rigidbody bullet; //bullet we will shoot
    public Transform bullet_spawn; //place where we spawn the bullets

    public AudioSource shooting_audio;
    public AudioClip charging_clip;
    public AudioClip fire_clip;

    //PARABOLIC SHOT VARIABLES
    public float v = 30f; //bullet valocity
    public float g = Physics.gravity.y;  //gravity
    public float x; //distance from tank to target
    public float y; //enemy height
    public float angle_sin; //angle before doing Mathf.atan
    public float angle; //shooting angle

    public float reloading_timer = 2f;
    public bool reloading = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        DetectEnemy();

        x = Vector3.Distance(target.transform.position, turret.transform.position);

        y = target.transform.position.y;

        //PARABOLIC SHOT FORMULA USED --> angle = (Mathf.Asin((g * x) / (v * v))/(2)

        float part1 = Mathf.Asin((g * x) / (v * v));
        angle_sin = part1 / 2;
        angle = Mathf.Asin(angle_sin) * Mathf.Rad2Deg;

        //rotate the turret
        if (enemy_detected)
        {
            //turret.transform.rotation = Quaternion.RotateTowards(turret.transform.rotation, target.transform.rotation, 30f * Time.deltaTime);
            //turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, target.transform.rotation, 2f);
            turret.transform.LookAt(target.transform);
            turret.transform.Rotate(turret.transform.right, angle, Space.World);
        }

        if (!reloading && enemy_detected)
        {
            ShootBullet();
        }
    
        if (reloading)
        {
            Reload();
        }
         
    }
    void ShootBullet()
    {
        Rigidbody new_bullet = Instantiate(bullet, bullet_spawn.position, Quaternion.identity);
        new_bullet.transform.LookAt(target.transform);
        new_bullet.velocity = turret.transform.forward * v;

        shooting_audio.clip = fire_clip;
        shooting_audio.Play();

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

    void DetectEnemy()
    {
        distance_to_enemy = Vector3.Distance(target.transform.position, transform.position);
        if (distance_to_enemy <= range_to_detect)
        {
            enemy_detected = true;
        }
        else
        {
            enemy_detected = false;
        }
    }
}
