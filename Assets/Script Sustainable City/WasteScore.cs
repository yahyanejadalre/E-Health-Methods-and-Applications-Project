using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class wasteScore : MonoBehaviour
{
    public int NumWasteObject = 0;

    void Update()
    {
        UpdateCanvasText();
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
                switch (NumWasteObject - 6)
                {
                    case 1:
                        textComponent.text = "Collected waste: 1/6";
                        break;
                    case 2:
                        textComponent.text = "Collected waste: 2/6";
                        break;
                    case 3:
                        textComponent.text = "Collected waste: 3/6";
                        break;
                    case 4:
                        textComponent.text = "Collected waste: 4/6";
                        break;
                    case 5:
                        textComponent.text = "Collected waste: 5/6";
                        break;
                    case 6:
                        textComponent.text = "Collected waste: 6/6";
                        break;
                    default:
                        textComponent.text = "Collected waste: 0/6";
                        break;
                }
            }
        }
    }
}

