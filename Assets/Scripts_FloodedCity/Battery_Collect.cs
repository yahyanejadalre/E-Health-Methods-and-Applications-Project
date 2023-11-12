using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BatteryCollect : MonoBehaviour
{
    public float interactionDistance = 2f; // Distanza di interazione
    public KeyCode interactKey = KeyCode.F; // Tasto per interagire
    private GameObject PlayerArmature; // Riferimento al GameObject del giocatore
    private GameObject levelStatusObject; // Riferimento al GameObject Level_status
    private levelStatus levelStatus; // Riferimento allo script LevelStatus
    private TextMeshProUGUI textInteraction;

    private void Start()
    {
        // Assicurati che il giocatore e il Level_status siano presenti nella scena
        PlayerArmature = GameObject.FindGameObjectWithTag("Player");
        levelStatusObject = GameObject.Find("Level_status");
        if (levelStatusObject != null)
        {
            levelStatus = levelStatusObject.GetComponent<levelStatus>();
        }
        textInteraction = GameObject.Find("Text_2").GetComponent<TextMeshProUGUI>();
        textInteraction.enabled = false;
        levelStatus.collect_enable = false;
    }

    private void Update()
    {
        if (PlayerArmature != null && (Vector3.Distance(PlayerArmature.transform.position, transform.position) <= interactionDistance) && levelStatus.collect_enable == true)
        {
            textInteraction.enabled = true;

            if (Input.GetKeyDown(interactKey))
            {
                if (levelStatus != null)
                {
                    // Incrementa il numero di batterie raccolte nello script LevelStatus
                    levelStatus.NumBatteriesCollected++;
                    levelStatus.updated = false;
                    levelStatus.collect_enable = false;
                }

                // Fai scomparire l'oggetto
                gameObject.SetActive(false);
                 levelStatus.collect_enable = false;  //Da sloccare quando si introducono dialoghi
            }
        }
        else
        {
            textInteraction.enabled = false;
        }
    }
}
