using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankUI : MonoBehaviour
{

    public Image ui_detected;
    Shoot shoot;

    private float count_down_reload;
    // Start is called before the first frame update
    void Start()
    {
        shoot = GetComponent<Shoot>();
        ui_detected.gameObject.SetActive(false);
        count_down_reload = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //UICountDown();
       
        EnemyDetectedUI();
    }

    void EnemyDetectedUI()
    {
        if(shoot.enemy_detected)
        {
            count_down_reload += Time.deltaTime;
            ui_detected.gameObject.SetActive(true);

            float offset_pos_y = transform.position.y + 5f;

            Vector3 offset_pos = new Vector3(transform.position.x, offset_pos_y, transform.position.z);

            Vector2 screen_point = Camera.main.WorldToScreenPoint(offset_pos);

            ui_detected.transform.position = screen_point;

            if (count_down_reload >= 2)
            {
                ui_detected.gameObject.SetActive(false);
            }
        }
    }
}
