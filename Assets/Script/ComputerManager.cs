using TMPro;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class ComputerManager : MonoBehaviour
{
    public GameObject pannelloConTesto;
    public GameObject OggettoComputer;
    public Level_Status_glacial Level_Status_glacial;
    public int distanzaMassima;


    void Start()
    {
        pannelloConTesto.SetActive(false);
        GameObject Canvas = GameObject.Find("ConversationCanvas");
        Transform Panel = Canvas.transform.Find("PanelComputer");
    }

    void Update()
    {
        // Qui inserisci la logica per verificare quando avvicini l'oggetto desiderato
        float distanza = Vector3.Distance(transform.position, OggettoComputer.transform.position);
        
        if (distanza <= distanzaMassima && Level_Status_glacial.NumCheck == 7)
        {
            pannelloConTesto.SetActive(true);
        }
    }
}
