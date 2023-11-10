using UnityEngine;

public class ScompareOggetto : MonoBehaviour
{
    // Dichiarazione della variabile nell'editor Unity
    public GameObject OggettoScompare;
    public float distanzaMassima;
    
    void Update()
    {
        if (OggettoScompare != null)
        {
            // Trova la distanza tra il giocatore e l'oggetto
            float distanza = Vector3.Distance(transform.position, OggettoScompare.transform.position);
            
            // Se il giocatore è abbastanza vicino, disattiva l'oggetto
            if (distanza <= distanzaMassima)
            {
                OggettoScompare.SetActive(false);
            }
        }
    }
}