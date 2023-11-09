using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float distanzaRilevamento = 2f; // Distanza a cui si attiverà l'apertura
    private bool isDoorOpen = false;

    void Update()
    {
        // Se il giocatore è abbastanza vicino e preme il tasto "F"
        if (Input.GetKeyDown(KeyCode.F) && IsPlayerNear())
        {
            // Inverte lo stato della porta (aperta o chiusa)
            isDoorOpen = !isDoorOpen;

            // Ruota la porta in base allo stato
            float angoloRotazione = isDoorOpen ? 90f : -90f;
            transform.Rotate(Vector3.up * angoloRotazione);
        }
    }

    bool IsPlayerNear()
    {
        // Trova il personaggio nella scena (assumendo che ci sia un solo personaggio)
        GameObject personaggio = GameObject.FindGameObjectWithTag("Player");

        // Se non ci sono personaggi, restituisci false
        if (personaggio == null)
        {
            return false;
        }

        // Calcola la distanza tra il personaggio e la porta
        float distanza = Vector3.Distance(personaggio.transform.position, transform.position);

        // Restituisci true se il personaggio è abbastanza vicino
        return distanza < distanzaRilevamento;
    }
}
