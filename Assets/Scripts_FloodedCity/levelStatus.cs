using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class levelStatus : MonoBehaviour
{
    public int NumBatteriesCollected = 0;
    public Vector3 Checkpoint;
    private GameObject playerObject;
    private GameObject Easy_mode;
    public bool updated = false;
    public bool collect_enable = false;
    public bool easy_mode_enabled; 

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player"); // Trova il GameObject del giocatore
        Easy_mode = GameObject.Find("Easy_mode");

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
