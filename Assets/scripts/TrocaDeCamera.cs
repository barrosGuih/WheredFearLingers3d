using UnityEngine;

public class TrocaDeCamera : MonoBehaviour
{
    public GameObject thirdCam;
    public GameObject firstCam;
    public GameObject mira;

    private bool firstPerson = false;

    void start()
    {
        Cursor.visible = false;                   // Esconde o mouse
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            firstPerson = !firstPerson;

            // garante troca instantânea
            thirdCam.SetActive(!firstPerson);
            firstCam.SetActive(firstPerson);

            // ativa a mira só em primeira pessoa
            if (mira != null)
                mira.SetActive(firstPerson);
        }
    }
}
