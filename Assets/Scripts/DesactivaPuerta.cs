using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivaPuerta : MonoBehaviour
{
    [SerializeField]
    GameObject puerta;

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
        if (other.GetComponent<CharacterController>())
            puerta.GetComponent<Collider>().enabled = true;
    }
}
