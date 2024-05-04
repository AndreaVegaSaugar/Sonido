using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colocado : MonoBehaviour
{
    bool colocado = false;

    [SerializeField]
    string color = ""; // Amarillo, Azul, Rojo o Verde (primera letra en mayus las demas minuscula)

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!colocado)
        {
            switch (color)
            {
                case "Amarillo":
                    if (esAmarillo(other))
                        enableColocado(true);
                    break;

                case "Azul":
                    if (esAzul(other))
                        enableColocado(true);
                    break;

                case "Rojo":
                    if (esRojo(other))
                        enableColocado(true);
                    break;

                case "Verde":
                    if (esVerde(other))
                        enableColocado(true);
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (colocado)
        {

            switch (color)
            {
                case "Amarillo":
                    if (esAmarillo(other))
                        enableColocado(false);
                    break;

                case "Azul":
                    if (esAzul(other))
                        enableColocado(false);
                    break;

                case "Rojo":
                    if (esRojo(other))
                        enableColocado(false);
                    break;

                case "Verde":
                    if (esVerde(other))
                        enableColocado(false);
                    break;
            }
        }
    }



    // Metodos privados propios
    void enableColocado(bool enable)
    {
        colocado = enable;

        if (enable)
            Debug.Log("Colocado");
        else
            Debug.Log("NOO");
    }

    bool esAmarillo(Collider colObj)
    {
        return colObj.GetComponent<Amarillo>() != null;
    }

    bool esAzul(Collider colObj)
    {
        return colObj.GetComponent<Azul>() != null;
    }

    bool esRojo(Collider colObj)
    {
        return colObj.GetComponent<Rojo>() != null;
    }

    bool esVerde(Collider colObj)
    {
        return colObj.GetComponent<Verde>() != null;
    }

    void sumaObjetoColocado()
    {
        GameManager.Instance.sumaObjeto();
    }

    void restaObjetoColocado()
    {
        GameManager.Instance.restaObjeto();
    }
}
