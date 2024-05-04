using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPos : MonoBehaviour
{

    Quaternion initialRotation;
    Vector3 initialPosition;


    // Start is called before the first frame update
    void Start()
    {
        Transform myTransform = transform;

        initialPosition = myTransform.position;
        initialRotation = myTransform.rotation;
    }

    public Quaternion getRotation()
    {
        return initialRotation;
    }

    public Vector3 getPosition()
    {
        return initialPosition;
    }
}
