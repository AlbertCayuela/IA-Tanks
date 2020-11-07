using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void GitHub()
    {
        Application.OpenURL("https://github.com/AlbertCayuela/IA");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
