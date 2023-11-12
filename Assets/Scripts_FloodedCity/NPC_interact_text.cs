using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_interact_text : MonoBehaviour
{
    public float interactionDistance = 2f; // Distanza di interazione
    public KeyCode interactKey = KeyCode.F; // Tasto per interagire
    private GameObject PlayerArmature; // Riferimento al GameObject del giocatore
    private GameObject levelStatusObject; // Riferimento al GameObject Level_status
    private levelStatus levelStatus; // Riferimento allo script LevelStatus
    private TextMeshProUGUI playerInteraction;
    private bool interacted = false;

    private void Start()
    {
        // Assicurati che il giocatore e il Level_status siano presenti nella scena
        PlayerArmature = GameObject.FindGameObjectWithTag("Player");
        levelStatusObject = GameObject.Find("Level_status");
        if (levelStatusObject != null)
        {
            levelStatus = levelStatusObject.GetComponent<levelStatus>();
        }
        playerInteraction = GameObject.Find("Text_3").GetComponent<TextMeshProUGUI>();
        playerInteraction.enabled = false;
    }

    private void Update()
    {
        if (PlayerArmature != null && (Vector3.Distance(PlayerArmature.transform.position, transform.position) <= interactionDistance) && interacted == false)
        {
            playerInteraction.enabled = true;

            if (Input.GetKeyDown(interactKey))
            {
                interacted = true;
                //gameObject.SetActive(false);
                playerInteraction.enabled = false;
                levelStatus.collect_enable = true;

            }
        }
        else
        {
            playerInteraction.enabled = false;
        }
    }
}
