using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Person
{
    public string name;
    public string gender;
    public int age;
    public string character;

    public Person(string name, string gender, int age, string character)
    {
        this.name = name;
        this.gender = gender;
        this.age = age;
        this.character = character;
    }
}

public class MainMenu : MonoBehaviour
{
    public static MainMenu mainMenu;
    public TMP_InputField NameInputFied;
    public TMP_InputField AgeInputFied;
    public Toggle maleToggle;
    public Toggle femaleToggle;
    private InputField[] Inputs;
    public void PlayGame()
    {
        string genderWithToggle="";
        if(maleToggle.isOn){
            genderWithToggle="male";
        }
        if(femaleToggle.isOn){
            genderWithToggle="female";
        }
        string character = "";
        if (int.Parse(AgeInputFied.text) < 50 && maleToggle.isOn)
        {
            character = "young man";
        }
        else if (int.Parse(AgeInputFied.text) < 50 && maleToggle.isOn)
        {
            character = "young woman";
        }
        else if (int.Parse(AgeInputFied.text) > 50 && femaleToggle.isOn)
        {
            character = "middle aged man";
        }
        else if (int.Parse(AgeInputFied.text) > 50 && femaleToggle.isOn)
        {
            character = "middle aged woman";
        }
        else
        {
            character = "error";
        }
        int AgeInputNumber = int.Parse(AgeInputFied.text);
        var NewPerson = new Person(NameInputFied.text,genderWithToggle,AgeInputNumber,character);
        print("name is " + NewPerson.name);
        print("gender is " + NewPerson.gender);
        print("age is "+ NewPerson.age);
        print("character is " + NewPerson.character);

        SceneManager.LoadSceneAsync("Lev1_House");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
