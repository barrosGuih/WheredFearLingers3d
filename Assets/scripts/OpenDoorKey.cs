using System.Collections;
using UnityEngine;

public class OpenDoorKey : MonoBehaviour
{
    [Header("Configuração da Porta")]
    public Transform porta;          // A parte que gira
    public float velocidade = 4f;    // Velocidade de animação
    public float anguloAberta = 90f; // Quanto ela abre (Y)

    [Header("Configuração do Jogador")]
    public playerInventory player;   // Referência ao script do player

    private bool aberta = false;
    private float anguloFechada = 0f;

    public GameObject msgPorta;

    void Update()
    {
        float alvo = aberta ? anguloAberta : anguloFechada;

        Quaternion rot = Quaternion.Euler(0, alvo, 0);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, rot, Time.deltaTime * velocidade);

    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (player.temChave)
                {
                    aberta = !aberta;        // alterna porta aberta/fechada
                }
                else
                {
                    msgPorta.SetActive(true);
                    StartCoroutine(EsconderMensagem());
                    Debug.Log("Você precisa de uma chave para abrir esta porta!");
                }
            }
        }

        

        
    }

    IEnumerator EsconderMensagem()
    {
        yield return new WaitForSeconds(2f); // tempo para ocultar
        msgPorta.SetActive(false);
    }
}
