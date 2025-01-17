﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinnerTextScript : MonoBehaviour
{

    public Text text_winner;
    public Text timer;
    public Text both_died;
    public GameObject wander_tank;
    public GameObject patrol_tank;
    public GameObject ui_tank;
    TankHealth wander_tank_health;
    TankHealth patrol_tank_health;
    Shoot patrol_shoot;
    Shoot wander_shoot;
    float end_timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        text_winner.gameObject.SetActive(false);
        both_died.gameObject.SetActive(false);
        wander_tank_health = wander_tank.GetComponent<TankHealth>();
        patrol_tank_health = patrol_tank.GetComponent<TankHealth>();
        patrol_shoot = patrol_tank.GetComponent<Shoot>();
        wander_shoot = wander_tank.GetComponent<Shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        if(wander_tank_health.m_CurrentHealth <= 0 && patrol_tank_health.m_CurrentHealth <= 0)
        {
            end_timer += Time.deltaTime;
            text_winner.gameObject.SetActive(false);
            both_died.gameObject.SetActive(true);
            timer.gameObject.SetActive(false);
            if(end_timer >= 3.0f)
            {
                SceneManager.LoadScene(2);
                Debug.Log("Loding End Menu");
            }

        }
        else if(wander_tank_health.m_CurrentHealth<=0 || patrol_tank_health.m_CurrentHealth <= 0)
        {
            end_timer += Time.deltaTime;
            text_winner.gameObject.SetActive(true);
            timer.gameObject.SetActive(false);
            patrol_shoot.enabled = false;
            wander_shoot.enabled = false;
            ui_tank.SetActive(false);
            if(end_timer >= 3.0f)
            {
                SceneManager.LoadScene(2);
                Debug.Log("Loading End Menu");
            }
        }
    }
}
