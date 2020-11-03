using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{

    public Text timerText;
    private float startTimer;
   

    // Start is called before the first frame update
    void Start()
    {
        startTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTimer;

        //string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        timerText.text = "Game timer: " + seconds +"s";

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
        }

    }
}
