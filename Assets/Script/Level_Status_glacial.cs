using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level_Status_glacial : MonoBehaviour
{
    public int NumCheck = 0;
    public Vector3 Checkpoint;
    private GameObject playerObject;
    public bool updated = false;
    public GameObject[] ArrayLight;
    public int NumIce = 1;
    public int pressCount = 0;
    
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player"); // Trova il GameObject del giocatore

        if (playerObject != null)
        {
            // Salva le coordinate iniziali del giocatore come Checkpoint
            Checkpoint = playerObject.transform.position;
        }
    }

    void Update()
    {
        SaveCheckpoint();
    }

    void SaveCheckpoint()
    {
        if (NumCheck > 0 && updated == false)
        {
            Checkpoint = GameObject.FindGameObjectWithTag("Player").transform.position;
            updated = true;
        }
    }
}
