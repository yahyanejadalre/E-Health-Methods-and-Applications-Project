using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText;
    private int currentLineIndex = 0;
    private string[] dialogLines;

    void Start()
    {
        dialogLines = new string[]
        {
            "Ciao, come stai?",
            "Sono bene, grazie! E tu?",
            "Anch'io sto bene, grazie per aver chiesto."
        };

        // Inizia il dialogo.
        StartCoroutine(StartDialog());
    }

    IEnumerator StartDialog()
    {
        foreach (string line in dialogLines)
        {
            dialogText.text = line;
            yield return new WaitForSeconds(2f); // Mostra ciascuna linea per 2 secondi.
            dialogText.text = ""; // Cancella il testo.
            yield return new WaitForSeconds(0.5f); // Attendi 0.5 secondi prima della prossima linea.
        }

        // Il dialogo è finito.
        Debug.Log("Dialogo terminato.");
    }
}