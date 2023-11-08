using UnityEngine;

public class RaccoltaOggetto : MonoBehaviour
{
    // Dichiarazione della variabile nell'editor Unity
    public GameObject oggettoDaRaccogliere;
    
    
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaccogliOggetto();
        }
    }

    void RaccogliOggetto()
    {
        if (oggettoDaRaccogliere != null)
        {
            // Trova la distanza tra il giocatore e l'oggetto
            float distanza = Vector3.Distance(transform.position, oggettoDaRaccogliere.transform.position);

            // Imposta una distanza massima per la raccolta
            float distanzaMassima = 2.0f;

            // Se il giocatore è abbastanza vicino, disattiva l'oggetto
            if (distanza <= distanzaMassima)
            {
                
                oggettoDaRaccogliere.SetActive(false);
                
            }
        }
        else
        {
            Debug.LogWarning("Assegna l'oggetto da raccogliere nell'Editor Unity!");
        }
    }
}