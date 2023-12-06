using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Conclusion : MonoBehaviour
{
    [SerializeField] public NPCConversation Conversation_Worsened;
    [SerializeField] public NPCConversation Conversation_Improved;
    private bool conversationStarted = false;
    private int cluster;
    private bool improved = true;
    private bool worsened = false;
    private float improvement = 0;
    private float worsening = 0;
    private float difference = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        improvement = levelStatus.improvement + Level_Status_glacial.improvement;
        worsening = levelStatus.worsening + Level_Status_glacial.worsening;
        difference = improvement - worsening;
        cluster = CLUSTERING_ALL_SCENES.cluster;
        if (difference > 5)
        {
            improved = true;
            worsened = false;
        }
        else
        {
            improved = false;
            worsened = true;
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
    // Gestisci l'avvio della conversazione se il giocatore è nel trigger
        if (other.CompareTag("Player") && !conversationStarted)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (improved || cluster == 1)
                {
                    ConversationManager.Instance.StartConversation(Conversation_Improved);
                    conversationStarted = true;
                }
                else if (worsened && cluster !=1)
                {
                    ConversationManager.Instance.StartConversation(Conversation_Worsened);
                    conversationStarted = true;
                }
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
