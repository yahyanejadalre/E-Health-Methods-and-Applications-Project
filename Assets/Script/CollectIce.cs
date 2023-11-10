using UnityEngine;

public class RaccoltaGhiaccio : MonoBehaviour
{
    // Dichiarazione della variabile nell'editor Unity
    public GameObject oggettoDaRaccogliere;
    private int pressCount = 0;
    public int nPress;
    public float distanzaMassima;
    
    
    void Update()
    {
        // Trova la distanza tra il giocatore e l'oggetto
        float distanza = Vector3.Distance(transform.position, oggettoDaRaccogliere.transform.position);
        
        // Se il giocatore è abbastanza vicino, disattiva l'oggetto
        if (distanza <= distanzaMassima)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                pressCount = pressCount + 1;
            }
            if (Input.GetKeyDown(KeyCode.F) && pressCount == nPress)
            {
                pressCount = pressCount + 1;
                RaccogliIce();
            }
        }
    }

    void RaccogliIce()
    {
        if (oggettoDaRaccogliere != null)
        {
            Destroy(oggettoDaRaccogliere);
        }
    }
}