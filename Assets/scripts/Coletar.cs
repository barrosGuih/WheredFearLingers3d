using UnityEngine;

public class Coletar : MonoBehaviour
{
    public GameObject collectUI;   // UI que aparece "Pressione E"
    public KeyCode collectKey = KeyCode.E;
    private bool playerNear = false;

    public GameObject Bag;

    void Start()
    {
        if (collectUI != null)
            collectUI.SetActive(false);
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(collectKey))
        {
            CollectItem();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
            if (collectUI != null)
                collectUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
            if (collectUI != null)
                collectUI.SetActive(false);
        }
    }

    void CollectItem()
    {
        // Aqui você pode somar pontuação, adicionar inventário, etc.
        Debug.Log("Item coletado!");

        if (collectUI != null)
            collectUI.SetActive(false);

        
        Bag.SetActive(true);
        Destroy(gameObject);  // Remove o item da cena
    }
}
