﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDownTimer : MonoBehaviour
{

    float currentTime = 0f;
    float startingTime =3f;

    [SerializeField] Text countdownText;
    // Start is called before the first frame update
    void Start()
    {

        currentTime = startingTime;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString(format:"0");

        if(currentTime <= 0)
        {
            currentTime = 0;
        }
        if(currentTime == 0)
        {
            countdownText.text = "Go";


        }
        
    }
}
