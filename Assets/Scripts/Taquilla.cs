using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taquilla : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag + " " + gameObject.tag);

        if (other.tag == "Player" && gameObject.tag == "Rojo")
        {
            GameManager.Instance.CorrectAula1();
        }
        else if (other.tag == "Player" && gameObject.tag != "Rojo")
        {
            GameManager.Instance.FailAula1();
        }
    }
}
