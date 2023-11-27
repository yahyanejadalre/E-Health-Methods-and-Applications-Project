using UnityEngine;
using TMPro;


public class GetOutCar : MonoBehaviour
{
    public GameObject oggettoDaRaccogliere;
    public GameObject carSecond;
    public float distanzaMassima;
    public TextMeshProUGUI interactText;
    private Transform figlio2car;
    private Transform figlio2people;
    
    
    private void Start()
    {
        // Assicura che il testo sia inizialmente nascosto all'avvio
        HideInteractMessage();
        carSecond.SetActive(false);
        Transform figlio1 = transform.Find("Geometry");
        if (figlio1 != null)
        {
            figlio2car = figlio1.Find("SM_Veh_Pickup_01");
            figlio2people = figlio1.Find("Character_BusinessMan_Shirt");
        }
    }
    
    void Update()
    {
        // Trova la distanza tra il giocatore e l'oggetto
        float distanza = Vector3.Distance(transform.position, oggettoDaRaccogliere.transform.position);
        
        // Se il giocatore è abbastanza vicino, disattiva l'oggetto
        if (distanza <= distanzaMassima)
        {
            ShowInteractMessage();
            GetOut();
        }
        else
        {
            HideInteractMessage();
        }
    }
    
    
    void GetOut()
    {
        if (oggettoDaRaccogliere != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                HideInteractMessage();
                oggettoDaRaccogliere.SetActive(false);
                DisactiveCar();
            }
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
    public void DisactiveCar()
    {
        if (figlio2car != null)
        {
            figlio2car.gameObject.SetActive(false);
            figlio2people.gameObject.SetActive(true);
            carSecond.SetActive(true);
        }
    }
}