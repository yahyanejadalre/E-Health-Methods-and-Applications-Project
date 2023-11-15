using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Human
{
    public string name;
    public string gender;
    public int age;
    public string character;

    public Human(string name, string gender, int age, string character)
    {
        this.name = name;
        this.gender = gender;
        this.age = age;
        this.character = character;
    }
}

public class MainMenu : MonoBehaviour
{
    public TMP_InputField NameInputFied;
    public TMP_InputField GenderInputFied;
    public TMP_InputField AgeInputFied;

    private List<Human> HumanList = new List<Human>();
    private List<InputField> InputList= new List<InputField>();
    private InputField[] Inputs;
    public void PlayGame()
    {
        string character = "";
        int AgeInputNumber = int.Parse(AgeInputFied.text);
        var NewHuman = new Human(NameInputFied.text,GenderInputFied.text,AgeInputNumber,character);
        Debug.Log("");
        print("name is " + NameInputFied.text);
        print("gender is " + GenderInputFied.text);
        print("age is "+ AgeInputNumber);
        print("character is " + character);

        SceneManager.LoadSceneAsync("Lev1_House");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
