using UnityEngine;
using TMPro;

public class RaccoltaGhiaccio : MonoBehaviour
{
    // Dichiarazione della variabile nell'editor Unity
    public GameObject oggettoDaRaccogliere;
    public float distanzaMassima;
    public Level_Status_glacial Level_Status_glacial;
    public int ActualIce;
    public TextMeshProUGUI interactText;
    
    private void Start()
    {
        // Assicura che il testo sia inizialmente nascosto all'avvio
        HideInteractMessage();
    }
    
    void Update()
    {
        // Trova la distanza tra il giocatore e l'oggetto
        float distanza = Vector3.Distance(transform.position, oggettoDaRaccogliere.transform.position);
        
        // Se il giocatore è abbastanza vicino, disattiva l'oggetto
        if (distanza <= distanzaMassima && oggettoDaRaccogliere != null)
        {
            ShowInteractMessage();
            if (Input.GetKeyDown(KeyCode.F))
            {
                Level_Status_glacial.pressCount++;
            }
            if (Level_Status_glacial.pressCount == 2 && Level_Status_glacial.NumIce == ActualIce)
            {
                RaccogliIce();
            }
        }
        else
        {
            HideInteractMessage();
        }
    }

    void RaccogliIce()
    {
        HideInteractMessage();
        if (oggettoDaRaccogliere != null)
        {
            Level_Status_glacial.pressCount = 0;
            oggettoDaRaccogliere.SetActive(false);
            Level_Status_glacial.NumIce++;
        }
    }
    private void ShowInteractMessage()
    {
        if (interactText != null)
        {
            interactText.gameObject.SetActive(true);
        }
    }

    private void HideInteractMessage()
    {
        if (interactText != null)
        {
            interactText.gameObject.SetActive(false);
        }
    }
}