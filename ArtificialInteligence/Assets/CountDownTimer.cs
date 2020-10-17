﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDownTimer : MonoBehaviour
{
    public int countDownTimer;
    public Text countDownDisplay;

    private void Start()
    {
        StartCoroutine(CountDown());

    }

    IEnumerator CountDown()
    {
        while(countDownTimer > 0)
        {
            countDownDisplay.text = countDownTimer.ToString();
            yield return new WaitForSeconds(1f);

            countDownTimer--;

        }

        countDownDisplay.text = "GO!";
        yield return new WaitForSeconds(1f);
        countDownDisplay.gameObject.SetActive(false);


    }
}
