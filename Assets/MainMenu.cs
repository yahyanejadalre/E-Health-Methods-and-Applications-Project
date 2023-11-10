using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField name_input, age_input;
    private string name;
    private int age;
    public void PlayGame()
    {
        // name = name_input.text;
        //age = Int32.Parse(age_input.text);
        // Save the variables here (e.g., PlayerPrefs or a database)
        SceneManager.LoadSceneAsync("Lev1_House");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
