using UnityEngine;
using TMPro;
using DialogueEditor;

public class ConverstaionStarter : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    public TextMeshProUGUI interactText;
    private bool conversationStarted = false;
    public Level_Status_glacial Level_Status_glacial;

    private void Start()
    {
        // Assicura che il testo sia inizialmente nascosto all'avvio
        HideInteractMessage();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !conversationStarted)
        {
            // Quando il giocatore entra, mostra il testo "Press F" sulla Canvas
            ShowInteractMessage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Quando il giocatore esce, nascondi il testo dalla Canvas
            HideInteractMessage();
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

    private void OnTriggerStay(Collider other)
    {
        // Gestisci l'avvio della conversazione se il giocatore è nel trigger
        if (other.CompareTag("Player") && !conversationStarted)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Level_Status_glacial.NumCheck++;
                Level_Status_glacial.ArrayLight[Level_Status_glacial.NumCheck - 1].SetActive(true);
                HideInteractMessage();
                ConversationManager.Instance.StartConversation(myConversation);
                conversationStarted = true;
            }
        }
    }
}