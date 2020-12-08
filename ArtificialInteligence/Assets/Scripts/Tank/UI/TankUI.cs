using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankUI : MonoBehaviour
{

    public Image ui_detected;
    public Image ui_reloading;

    public GameObject target;

    Shoot shoot;
    TankHealth tank_health;
    TankHealth target_health;

    private float count_down_detected;
    private float count_down_reload;
    // Start is called before the first frame update
    void Start()
    {
        shoot = GetComponent<Shoot>();
        ui_detected.gameObject.SetActive(false);
        ui_reloading.gameObject.SetActive(false);
        count_down_detected = 0f;
        count_down_reload = 0f;
        tank_health = GetComponent<TankHealth>();
        target_health = target.GetComponent<TankHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        //UICountDown();
       
        EnemyDetectedUI();
        if (tank_health.m_CurrentHealth > 0 && target_health.m_CurrentHealth > 0)
            ReloadingUI();
        else if(tank_health.m_CurrentHealth<=0 || target_health.m_CurrentHealth<=0)
            ui_reloading.gameObject.SetActive(false);


    }

    void EnemyDetectedUI()
    {
        if(shoot.enemy_detected)
        {
            count_down_detected += Time.deltaTime;
            ui_detected.gameObject.SetActive(true);

            float offset_pos_y = transform.position.y + 5f;

            Vector3 offset_pos = new Vector3(transform.position.x, offset_pos_y, transform.position.z);

            Vector2 screen_point = Camera.main.WorldToScreenPoint(offset_pos);

            ui_detected.transform.position = screen_point;

            if (count_down_detected >= 2)
            {
                ui_detected.gameObject.SetActive(false);
            }
        }
    }

    void ReloadingUI()
    {
        if (shoot.reloading || shoot.bullets <= 0)
        {
            count_down_reload += Time.deltaTime;
            //ui_reloading.gameObject.SetActive(true);
            float r_offset_pos_y = transform.position.y + 3f;
            Vector3 r_offset_pos = new Vector3(transform.position.x, r_offset_pos_y, transform.position.z);
            Vector2 r_screen_point = Camera.main.WorldToScreenPoint(r_offset_pos);
            ui_reloading.transform.position = r_screen_point;
            if(count_down_reload >= 0.5)
            {
                ui_reloading.gameObject.SetActive(true);
                count_down_reload = 0f;
            }
        }
        else if(!shoot.reloading)
        {
            ui_reloading.gameObject.SetActive(false);
            count_down_reload = 0f;
        }
       
    }
}
