using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public GameObject pausePanel;
    //public GameObject br;
    public GameObject pausebutton;

    private void start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    public void Pause()
    {
        Time.timeScale = 0;
       // br.SetActive(false);
        pausebutton.SetActive(false);
        pausePanel.SetActive(true);
        //enable the scripts again
    }
    public void Resume()
    {
        Time.timeScale = 1;
        //br.SetActive(true);
        pausebutton.SetActive(true);
        pausePanel.SetActive(false);
        //enable the scripts again
    }
    public void Replay()
    {
        
        //LapTimeManager.updtime = false;
        LapTimeManager.MilliCount = 0;
        LapTimeManager.SecCount = 0;
        LapTimeManager.MinCount = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Back()
    {
        LapTimeManager.MilliCount = 0;
        LapTimeManager.SecCount = 0;
        LapTimeManager.MinCount = 0;
        //LapTimeManager.updtime = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
