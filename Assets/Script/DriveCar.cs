using StarterAssets;
using UnityEngine;
using TMPro;
using Cinemachine;



public class CarController : MonoBehaviour
{
    
    public GameObject oggettoDaRaccogliere;
    public float distanzaMassima;
    public TextMeshProUGUI interactText;
    private Transform figlio2car;
    private Transform figlio2people;
    public Level_Status_glacial Level_Status_glacial;
    public int ActualCheck;
    public ThirdPersonController ThirdPersonController;
    public CinemachineVirtualCamera CinemachineVirtualCamera;

    
    
    private void Start()
    {
        // Assicura che il testo sia inizialmente nascosto all'avvio
        HideInteractMessage();
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
        if (distanza <= distanzaMassima && Level_Status_glacial.NumCheck == ActualCheck)
        {
            ShowInteractMessage();
            Drive();
        }
        else
        {
            HideInteractMessage();
        }
    }
    
    
    void Drive()
    {
        if (oggettoDaRaccogliere != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Level_Status_glacial.NumCheck++;
                Level_Status_glacial.ArrayLight[Level_Status_glacial.NumCheck - 1].SetActive(true);
                HideInteractMessage();
                oggettoDaRaccogliere.SetActive(false);
                ActiveCar();
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
    public void ActiveCar()
    {
        if (figlio2car != null)
        {
            figlio2car.gameObject.SetActive(true);
            figlio2people.gameObject.SetActive(false);
            ThirdPersonController.MoveSpeed = 5.0f;
            ThirdPersonController.SprintSpeed = 12.5f;
            ThirdPersonController.RotationSmoothTime = 0.27f;
            ThirdPersonController.JumpHeight = 0f;
            CinemachineVirtualCamera.m_Lens.FieldOfView = 70.0f;
        }
    }
}