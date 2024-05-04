using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taquilla : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("NOOOOOOO EL DALTONICO");
        }
    }
}
