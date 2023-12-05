using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float countdownTime = 5.0f; // Imposta il tempo di countdown desiderato in secondi
    private float currentTime = 0.0f;
    private bool timerActive = false;
    public Level_Status_glacial Level_Status_glacial;

    void Start()
    {
        if (Level_Status_glacial.timer_enable)
        {
            StartTimer();
        }
    }

    void Update()
    {
        if (timerActive)
        {
            currentTime += Time.deltaTime;

            // Aggiorna la UI o esegui azioni quando il tempo è scaduto
            if (currentTime >= countdownTime)
            {
                TimerEnded();
            }
        }
    }

    public void StartTimer()
    {
        // Avvia il timer
        currentTime = 0.0f;
        timerActive = true;
    }

    public void StopTimer()
    {
        // Ferma il timer
        timerActive = false;
    }

    void TimerEnded()
    {
        // Azioni da eseguire quando il tempo è scaduto
        Debug.Log("Tempo scaduto!");
        // Puoi aggiungere altre azioni qui, come cambiare scena o attivare/disattivare oggetti
    }
}
