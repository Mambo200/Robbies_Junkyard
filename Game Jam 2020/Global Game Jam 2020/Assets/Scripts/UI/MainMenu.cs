using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Game is starting");
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
