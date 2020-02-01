using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingMenu : MonoBehaviour
{
    public void QuitButton()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Game is starting");
    }
}
