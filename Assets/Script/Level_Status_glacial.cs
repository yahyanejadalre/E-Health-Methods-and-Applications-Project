using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level_Status_glacial : MonoBehaviour
{
    public int NumCheck = 0;
    public Vector3 Checkpoint;
    private GameObject playerObject;
    public bool updated = false;
    public GameObject[] ArrayLight;
    public int NumIce = 1;
    public int pressCount = 0;
    public bool timer_enable;
    public int cluster = 1;
    public float improvement = 0;
    private string character;
    private int age = 0;
    public GameObject middle_age_men;
    public GameObject middle_age_women;
    public GameObject young_men;
    public GameObject young_women;
    
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player"); // Trova il GameObject del giocatore
        character = MainMenu.character;
        age = MainMenu.age;
        cluster = CLUSTERING_ALL_SCENES.cluster;
        if (character == "young man")
        {
            young_men.SetActive(true);
            }
        if (character == "young woman")
        {
            young_men.SetActive(false);
            young_women.SetActive(true);
        }
        if (character == "middle aged man")
        {
            young_men.SetActive(false);
            middle_age_men.SetActive(true);
        }
        if (character == "middle aged woman")
        {
            young_men.SetActive(false);
            middle_age_women.SetActive(true);
        }

        if (age >= 35)
        {
            timer_enable = false;
        }
        else
        {
            timer_enable = false;
        }
        if (playerObject != null)
        {
            // Salva le coordinate iniziali del giocatore come Checkpoint
            Checkpoint = playerObject.transform.position;
        }
    }

    void Update()
    {
        SaveCheckpoint();
    }

    void SaveCheckpoint()
    {
        if (NumCheck > 0 && updated == false)
        {
            Checkpoint = GameObject.FindGameObjectWithTag("Player").transform.position;
            updated = true;
        }
    }
}
