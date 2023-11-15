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
    public string name
    {
        get { return name; }   // get method
        set { name = value; }  // set method
    }
    public string gender
    {
        get { return gender; }   // get method
        set { gender = value; }  // set method
    }
    public int age
    {
        get { return age; }   // get method
        set { age = value; }  // set method
    }
    public string character
    {
        get { return character; }   // get method
        set { character = value; }  // set method
    }

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
    public TMP_InputField NameInputFied;
    public TMP_InputField GenderInputFied;
    public TMP_InputField AgeInputFied;

    private List<Person> HumanList = new List<Person>();
    private List<InputField> InputList= new List<InputField>();
    private InputField[] Inputs;
    public void PlayGame()
    {
        string character = "";
        if (int.Parse(AgeInputFied.text) < 50 && GenderInputFied.text == "male")
        {
            character = "young man";
        }
        else if (int.Parse(AgeInputFied.text) < 50 && GenderInputFied.text == "female")
        {
            character = "young woman";
        }
        else if (int.Parse(AgeInputFied.text) > 50 && GenderInputFied.text == "male")
        {
            character = "middle aged man";
        }
        else if (int.Parse(AgeInputFied.text) > 50 && GenderInputFied.text == "female")
        {
            character = "middle aged woman";
        }
        else
        {
            character = "error";
        }
        int AgeInputNumber = int.Parse(AgeInputFied.text);
        var NewPerson = new Person(NameInputFied.text,GenderInputFied.text,AgeInputNumber,character);
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
