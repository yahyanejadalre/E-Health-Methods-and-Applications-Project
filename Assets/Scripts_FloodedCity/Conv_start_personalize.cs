using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conv_start_personalize : MonoBehaviour
{
    [SerializeField] public NPCConversation Conversation_Sceptical;
    [SerializeField] public NPCConversation Conversation_Anxious;
    [SerializeField] public NPCConversation Conversation_Normal;
    private bool conversationStarted = false;
    private int cluster;


    // Start is called before the first frame update
    void Start()
    {
        cluster = CLUSTERING_ALL_SCENES.cluster;

        cluster = 3;
    }

    private void OnTriggerStay(Collider other)
    {
        // Gestisci l'avvio della conversazione se il giocatore � nel trigger
        if (other.CompareTag("Player") && !conversationStarted)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (cluster == 1)
                {
                    ConversationManager.Instance.StartConversation(Conversation_Anxious);
                    conversationStarted = true;
                }
                else if (cluster == 2)
                {
                    ConversationManager.Instance.StartConversation(Conversation_Normal);
                    conversationStarted = true;
                }
                else if (cluster == 3)
                {
                    ConversationManager.Instance.StartConversation(Conversation_Sceptical);
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