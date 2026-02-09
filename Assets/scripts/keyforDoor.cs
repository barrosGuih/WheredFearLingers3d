using UnityEngine;

public class keyforDoor : MonoBehaviour
{
    public playerInventory player;   // referência ao player
    public GameObject uiPressE;      // texto "Pressione E"

    private bool podePegar = false;

    void Update()
    {
        if (podePegar && Input.GetKeyDown(KeyCode.F))
        {
            player.temChave = true;   // dá a chave
            Debug.Log("Chave coletada!");

            if (uiPressE != null)
                uiPressE.SetActive(false);

            Destroy(gameObject);      // destrói a chave
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            podePegar = true;

            if (uiPressE != null)
                uiPressE.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            podePegar = false;

            if (uiPressE != null)
                uiPressE.SetActive(false);
        }
    }
}
