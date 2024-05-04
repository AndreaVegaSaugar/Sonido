using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        InitialPos objIniScript = collision.gameObject.GetComponent<InitialPos>();

        if (objIniScript != null)
        {
            collision.transform.SetPositionAndRotation(objIniScript.getPosition(), objIniScript.getRotation());
            collision.rigidbody.velocity = new Vector3(0, 0, 0);
        }
    }
}
