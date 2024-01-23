using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L2_LoadingScreen : MonoBehaviour
{
    public string currentScene;
    public string nextScene;


    public void restart()
    {
        SceneManager.LoadScene("Scenes/" + currentScene);
        Time.timeScale = 1;
    }
    // zet name van volgend level in nextScene in Unity zelf
    public void nextlevel()
    {
        SceneManager.LoadScene("Scenes/" + nextScene);
        Time.timeScale = 1;
    }
    // zet name main menu op main
    public void quit()
    {
        SceneManager.LoadScene("Scenes/main");
    }
}
