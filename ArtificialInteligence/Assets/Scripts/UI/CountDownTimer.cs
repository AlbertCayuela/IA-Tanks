using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDownTimer : MonoBehaviour
{
    public int countDownTimer;
    public Text countDownDisplay;

    public GameObject patrol_tank_manager;
    public GameObject wander_tank_manager;
    public GameObject pause_objects;

    public Text timer_text;
    Timer timer;

    private void Start()
    {
        StartCoroutine(CountDown());
        wander_tank_manager.GetComponent<TankStateManager>().enabled = false;
        patrol_tank_manager.GetComponent<TankStateManager>().enabled = false;
        pause_objects.SetActive(false);
        timer = GetComponent<Timer>();
        timer_text.gameObject.SetActive(false);
    }

    IEnumerator CountDown()
    {
       
        while (countDownTimer > 0 )
        {
           
            countDownDisplay.text = countDownTimer.ToString();
         
            yield return new WaitForSeconds(1f);
           
            countDownTimer--;

        }

        countDownDisplay.text = "GO!";
        yield return new WaitForSeconds(1f);
        countDownDisplay.gameObject.SetActive(false);
        wander_tank_manager.GetComponent<TankStateManager>().enabled = true;
        //patrol_tank_manager.GetComponent<TankStateManager>().enabled = true;
        timer.enabled = true;
        timer_text.gameObject.SetActive(true);
    }
}
