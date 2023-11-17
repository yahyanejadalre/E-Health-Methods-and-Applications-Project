using System.Collections;
using StarterAssets;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject playerArmature;
    public float distanzaMassima;
    //private bool isPlayerDriving = false;
    public GameObject oggettoDaGuidare;
    
    void Update()
    {
        // Trova la distanza tra il giocatore e l'oggetto
        float distanza = Vector3.Distance(transform.position, oggettoDaGuidare.transform.position);
        
        // Se il giocatore è abbastanza vicino, disattiva l'oggetto
        if (distanza <= distanzaMassima && Input.GetKeyDown(KeyCode.F))
        {
            SwitchControl();
        }
    }
    
    

    void SwitchControl()
    {
        // Disable the CharacterController and make the character invisible
        playerArmature.GetComponent<ThirdPersonController>().enabled = false;
       
        // Set the character as a child of the car
        playerArmature.transform.parent = transform;

        // Enable the car controller
        oggettoDaGuidare.GetComponent<ThirdPersonController>().enabled = true;
       


        /*// Disable the car controller
        GetComponent<CarController>().enabled = false;

        // Set the character's parent to null (remove parenting)
        playerArmature.transform.parent = null;

        // Enable the CharacterController and make the character visible again
        playerArmature.GetComponent<ThirdPersonController>().enabled = true;
        playerArmature.GetComponent<MeshRenderer>().enabled = true;

        // Change the player's control state
        isPlayerDriving = !isPlayerDriving;*/
    }
}