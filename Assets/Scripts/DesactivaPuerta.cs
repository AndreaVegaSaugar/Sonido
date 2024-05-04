using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivaPuerta : MonoBehaviour
{
    [SerializeField]
    string nombreAula;

    [SerializeField]
    GameObject puerta;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {
            puerta.GetComponent<Collider>().enabled = true;

            if (nombreAula == "Aula1") GameManager.Instance.StartAula1();
            if (nombreAula == "Aula2") GameManager.Instance.StartAula2();
        }
    }
}
