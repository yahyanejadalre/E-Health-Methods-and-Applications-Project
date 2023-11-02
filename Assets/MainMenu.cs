using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        // Save the variables here (e.g., PlayerPrefs or a database)
        SceneManager.LoadSceneAsync("Lev1_House");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
