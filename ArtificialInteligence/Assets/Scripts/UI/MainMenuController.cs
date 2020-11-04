using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject game;
    public GameObject ui_ingame;
    // Start is called before the first frame update
    void Start()
    {
        game.GetComponent<CountDownTimer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        game.GetComponent<CountDownTimer>().enabled = true;
        ui_ingame.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void GitHub()
    {
        Application.OpenURL("https://github.com/AlbertCayuela/IA");
    }

    public void Extit()
    {
        Application.Quit();
    }
}
