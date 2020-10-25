using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankUI : MonoBehaviour
{

    public Image ui_detected;
    public GameObject tank;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float offset_pos_y = transform.position.y + 2f;

        Vector3 offset_pos = new Vector3(transform.position.x, offset_pos_y, transform.position.z);

        Vector2 screen_point = Camera.main.WorldToScreenPoint(offset_pos);

        ui_detected.transform.position = screen_point;

        //RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas)
    }
}
