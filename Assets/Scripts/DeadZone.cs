using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        InitialPos objIniScript = other.gameObject.GetComponent<InitialPos>();
        
        if (objIniScript != null)
        {
            other.transform.SetPositionAndRotation(objIniScript.getPosition(), objIniScript.getRotation());
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

}
