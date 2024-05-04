using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
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

    string playerName = "Denica";

    // Aula 2
    int objetosColocados = 0;
    bool sala2Completada = false;

    [SerializeField]
    int numObjetosAula2;

    [SerializeField]
    GameObject bloqueoPuerta2;

    // Aula 1
    [SerializeField]
    TextMeshProUGUI TextoAula1;
    [SerializeField]
    TextMeshProUGUI TextoAula2;

    string[] colores = { "Rojo", "Azul", "Amarillo", "Verde" };
    string colorTaquilla = "Rojo";



    // METODOS
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        numObjetosAula2 = numObjetosAula2 * 3; // 3 es el num de objetos de cada cofre
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(objetosColocados);
    }



    // Aula 2
    public void sumaObjeto()
    {
        objetosColocados++;
        if (objetosColocados == numObjetosAula2)
        {
            sala2Completada = true;
            Debug.Log("Sala 2 Completada");

            // Desactivo Bloqueo Puerta
            bloqueoPuerta2.SetActive(false);
        }
    }

    public void restaObjeto()
    {
        objetosColocados--;
    }

    // Aula 1

    public void StartAula1()
    {
        TextoAula1.text = "Cada uno tiene que poner sus cosas en la taquilla de su color. " + playerName + ", tu taquilla es la roja, ve a guardar tus cosas.";
    }

    public void StartAula2()
    {
        TextoAula2.text = "La sala de juegos esta hecha un desaste. " + playerName + ", guarda cada juguete en el cofre de su color.";
    }
}
