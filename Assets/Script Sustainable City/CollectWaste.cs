using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class RaccoltaRifiuto : MonoBehaviour
{
    public static WasteObject oggettoRaccolto;
    public WasteObject oggettoDaRaccogliere;
    private bool inPossessoDiOggetto = false;
    [SerializeField] private NPCConversation myConversation;


    private void OnTriggerStay(Collider other)
    {
       if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                RaccogliOggetto(oggettoDaRaccogliere);
                ConversationManager.Instance.StartConversation(myConversation);
            }
        }
    }

    void RaccogliOggetto(WasteObject oggetto)
    {
        if (oggetto != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!inPossessoDiOggetto)
                {
                    oggettoDaRaccogliere = oggettoRaccolto;
                    oggettoRaccolto = oggetto;
                    oggetto.gameObject.SetActive(false);
                    inPossessoDiOggetto = true;
                }
            }
        }
    }
}
