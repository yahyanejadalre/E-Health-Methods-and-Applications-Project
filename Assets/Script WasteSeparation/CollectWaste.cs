using UnityEngine;

public class RaccoltaRifiuto : MonoBehaviour
{
    public static WasteObject oggettoRaccolto;
    public WasteObject oggettoDaRaccogliere;
    private bool inPossessoDiOggetto = false;

    private void OnTriggerStay(Collider other)
    {
       if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                RaccogliOggetto(oggettoDaRaccogliere);
            }
        }
    }

    void RaccogliOggetto(WasteObject oggetto)
    {
        if (oggetto != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!inPossessoDiOggetto)
                {
                    oggettoDaRaccogliere = oggettoRaccolto;
                    oggettoRaccolto = oggetto;
                    oggetto.gameObject.SetActive(false);
                    inPossessoDiOggetto = true;
                }
            }
        }
    }
}
