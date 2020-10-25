using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankUI : MonoBehaviour
{

    public Image ui_detected;
    Shoot shoot;
   
  
    // Start is called before the first frame update
    void Start()
    {
        shoot = GetComponent<Shoot>();
        ui_detected.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        EnemyDetectedUI();
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas)
    }

    void EnemyDetectedUI()
    {
        if(shoot.enemy_detected)
        {
        ui_detected.gameObject.SetActive(true);

        float offset_pos_y = transform.position.y + 5f;

        Vector3 offset_pos = new Vector3(transform.position.x, offset_pos_y, transform.position.z);

        Vector2 screen_point = Camera.main.WorldToScreenPoint(offset_pos);

        ui_detected.transform.position = screen_point;
        }
        ui_detected.gameObject.SetActive(false);
    }
}
