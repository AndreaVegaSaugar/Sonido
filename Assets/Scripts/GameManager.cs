using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Basicos GameManager
    static private GameManager _instance;
    static public GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    // VARIABLES

    // Aula 2
    int objetosColocados = 0;
    bool sala2Completada = false;

    [SerializeField]
    int numObjetosAula2;

    [SerializeField]
    GameObject bloqueoPuerta2;


    // METODOS
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    // Publico
    public void sumaObjeto()
    {
        objetosColocados++;
        if (objetosColocados == numObjetosAula2)
        {
            sala2Completada = true;
            Debug.Log("Sala 2 Completada");

            // Desacctivo Bloqueo Puerta
        }
    }

    public void restaObjeto()
    {
        objetosColocados--;
    }

}
