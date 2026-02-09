using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool aberta = false;
    public float velocidade = 4f;

    private float fechada = 0f;
    public float abertaAngulo = 90f;

    void Update()
    {
        float alvo = aberta ? abertaAngulo : fechada;
        Quaternion rot = Quaternion.Euler(0, alvo, 0);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, rot, Time.deltaTime * velocidade);
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            aberta = !aberta;
        }
    }
}