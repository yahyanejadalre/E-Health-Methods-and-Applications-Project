using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteSeparation_new : MonoBehaviour
{
    WasteObject oggettoRaccolto;
    public int tipoCassonetto;
    private GameObject wasteScoreObject;
    private wasteScore wasteScore;

    void Awake()
    {
        wasteScoreObject = GameObject.Find("WasteScore");
        if (wasteScoreObject != null)
        {
            wasteScore = wasteScoreObject.GetComponent<wasteScore>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                // Verifica se RaccoltaRifiuto.oggettoRaccolto non è null prima di assegnare il suo valore a oggettoRaccolto
                if (RaccoltaRifiuto.oggettoRaccolto != null)
                {
                    oggettoRaccolto = RaccoltaRifiuto.oggettoRaccolto;

                    if (oggettoRaccolto.typeWaste == tipoCassonetto)
                    {
                        Destroy(oggettoRaccolto.gameObject);
                        Debug.Log("è stato buttato un rifiuto di tipo: " + oggettoRaccolto.typeWaste);
                        wasteScore.NumWasteObject++;
                        Debug.Log("NumWasteObject after increment: " + wasteScore.NumWasteObject);
                    }
                }
            }
        }
    }
}