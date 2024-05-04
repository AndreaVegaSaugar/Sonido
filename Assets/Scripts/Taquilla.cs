using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taquilla : MonoBehaviour
{
    // Start is called before the first frame update

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("NOOOOOOO EL DALTONICO");
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
