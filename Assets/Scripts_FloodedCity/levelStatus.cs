using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;
using Unity.VisualScripting;

public class levelStatus : MonoBehaviour
{
    public int NumBatteriesCollected = 0;
    public Vector3 Checkpoint;
    private GameObject playerObject;
    private GameObject Easy_mode;
    private GameObject Improvement;
    private GameObject Worsening;
    public bool updated = false;
    public bool collect_enable = false;
    public bool easy_mode_enabled;
    public int cluster = 1;
    public float improvement = 0;
    public float worsening = 0;
    //bool male = false;
    //int age = 0;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player"); // Trova il GameObject del giocatore
        Easy_mode = GameObject.Find("Easy_mode");
        Improvement = GameObject.Find("Improvement");
        Worsening = GameObject.Find("Worsening");
        cluster = CLUSTERING_ALL_SCENES.cluster;

        //male = MainMenu.maleToggle.isOn;
        //age = int.Parse(MainMenu.AgeInputFied.text);
            
        if (playerObject != null)
        {
            // Salva le coordinate iniziali del giocatore come Checkpoint
            Checkpoint = playerObject.transform.position;
        }

        if(easy_mode_enabled == true)
        {
            Easy_mode.SetActive(true);
        }
        else
        {
            Easy_mode.SetActive(false);
        }
    }

    void Update()
    {
        UpdateCanvasText();
        SaveCheckpoint();

        improvement = Improvement.transform.position.y;
        worsening = Worsening.transform.position.y;

        if (improvement > 0)
        {
            Debug.Log("Improvement:" + improvement);
        }

        if (worsening > 0)
        {
            Debug.Log("Worsening:" + worsening);
        }

    }

    void UpdateCanvasText()
    {
        // Codice per aggiornare il testo nel Canvas
        // ...

        // Trova il GameObject del Canvas
        GameObject canvasObject = GameObject.Find("Canvas"); // Sostituisci "NomeDelTuoCanvas" con il nome effettivo del tuo GameObject Canvas

        if (canvasObject != null)
        {
            TextMeshProUGUI textComponent = canvasObject.GetComponentInChildren<TextMeshProUGUI>();

            if (textComponent != null)
            {
                switch (NumBatteriesCollected)
                {
                    case 1:
                        textComponent.text = "Collected batteries: 1/3";
                        break;
                    case 2:
                        textComponent.text = "Collected batteries: 2/3";
                        break;
                    case 3:
                        textComponent.text = "Collected batteries: 3/3";
                        break;
                    default:
                        textComponent.text = "Collected batteries: 0/3";
                        break;
                }
            }
        }
    }

    void SaveCheckpoint()
    {
        if (NumBatteriesCollected > 0 && updated == false)
        {
            Checkpoint = GameObject.FindGameObjectWithTag("Player").transform.position;
            updated = true;
        }
    }
}
