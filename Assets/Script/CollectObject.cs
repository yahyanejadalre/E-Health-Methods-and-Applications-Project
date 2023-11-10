using UnityEngine;

public class RaccoltaOggetto : MonoBehaviour
{
    // Dichiarazione della variabile nell'editor Unity
    public GameObject oggettoDaRaccogliere;
    public float distanzaMassima;

    
    void Update()
    {
        // Trova la distanza tra il giocatore e l'oggetto
        float distanza = Vector3.Distance(transform.position, oggettoDaRaccogliere.transform.position);
        
        // Se il giocatore è abbastanza vicino, disattiva l'oggetto
        if (distanza <= distanzaMassima)
        {
            RaccogliOggetto();
        }
    }

    void RaccogliOggetto()
    {
        if (oggettoDaRaccogliere != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                oggettoDaRaccogliere.SetActive(false);
            }
        }
    }
}