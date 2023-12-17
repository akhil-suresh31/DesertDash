using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Track1");
    }

    public void LoadInst()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void LoadCred()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
