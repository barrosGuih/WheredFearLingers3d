using UnityEngine;

public class AbrirItem : MonoBehaviour
{
    [Header("Configurações de UI")]
    public GameObject collectUI;   // UI que aparece "Pressione E"
    public KeyCode collectKey = KeyCode.E;
    private bool playerNear = false;

    [Header("Itens para Ativar")]
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;

    void Awake()
    {
        // PROTEÇÃO: Se você esqueceu de arrastar os itens no Inspector, 
        // criamos um objeto vazio para não dar erro de "NullReference"
        VerificarReferencia(ref item1, "Item1_Placeholder");
        VerificarReferencia(ref item2, "Item2_Placeholder");
        VerificarReferencia(ref item3, "Item3_Placeholder");
    }

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

    // Função auxiliar para evitar erros de variável vazia
    void VerificarReferencia(ref GameObject obj, string nomePlaceholder)
    {
        if (obj == null)
        {
            // Cria um objeto invisível para ocupar o lugar da variável vazia
            obj = new GameObject(nomePlaceholder);
            obj.SetActive(false); // Começa desativado
            Debug.LogWarning($"Cuidado: Você não preencheu o {nomePlaceholder} no script {gameObject.name}. Criei um invisível no lugar.");
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
        Debug.Log("Interagindo com o objeto!");

        // Esconde a mensagem "Pressione E"
        if (collectUI != null)
            collectUI.SetActive(false);

        // Ativa os itens (se forem os placeholders invisíveis, nada acontece visualmente)
        item1.SetActive(true);
        item2.SetActive(true);
        item3.SetActive(true);

        // AQUI ESTÁ A MUDANÇA:
        // Não destrua a "collectUI" (se não ela some do jogo todo).
        // Destrua este objeto (o baú ou item que você abriu)
        Destroy(collectUI); 
    }
}