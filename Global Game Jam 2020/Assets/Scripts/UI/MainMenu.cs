using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void StartButton(InputField _inputField)
    {
        if(_inputField.text == null
            || string.IsNullOrWhiteSpace(_inputField.text)
            || string.IsNullOrEmpty(_inputField.text))
        {
            Debug.Log("Null or white space or empty");
            return;
        }
        PlayerController.PlayerName = _inputField.text;
        MyRandom.SetSeed();
        SceneManager.LoadScene(1);
        Debug.Log("Game is starting");
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
