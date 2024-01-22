using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLevel : MonoBehaviour
{
    public Canvas canvas;

    public void loadlevel()
    {

        //load the new level
        Time.timeScale = 1;

        canvas.enabled = false;
    }
}
