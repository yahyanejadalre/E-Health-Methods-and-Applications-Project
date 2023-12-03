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
    private GameObject levelStatusObject; // Riferimento al GameObject Level_status
    private levelStatus levelStatus; // Riferimento allo script LevelStatus


    // Start is called before the first frame update
    void Start()
    {
        levelStatusObject = GameObject.Find("Level_status");
        levelStatus = levelStatusObject.GetComponent<levelStatus>();
        cluster = levelStatus.cluster;
    }

    private void OnTriggerStay(Collider other)
    {
        // Gestisci l'avvio della conversazione se il giocatore è nel trigger
        if (other.CompareTag("Player") && !conversationStarted)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (cluster == 1)
                {
                    ConversationManager.Instance.StartConversation(Conversation_Anxious);
                    conversationStarted = true;
                }
                if (cluster == 2)
                {
                    ConversationManager.Instance.StartConversation(Conversation_Normal);
                    conversationStarted = true;
                }
                if (cluster == 3)
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
