using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Rendering.PostProcessing;
public class ButtonFollowVisual : MonoBehaviour
{
    public Transform visualTarget;
    public Vector3 localAxis;
    public float resetSpeed = 5.0f;
    public float followAngle = 45;
    public Camera cam;
    public float _idButton = 0;
    private bool freeze = false;

    private Vector3 offset;
    private Vector3 initialLocalPos;
    private Transform pokeAttachTransform;

    private XRBaseInteractable interactable;
    private bool isFollowing = false;
    // Start is called before the first frame update
    void Start()
    {
        initialLocalPos = visualTarget.localPosition;
        interactable = GetComponent<XRBaseInteractable>();
    }

    public void Reset(BaseInteractionEventArgs hover)
    {
        if (hover.interactable is XRPokeInteractor)
        {
            isFollowing = false;
            freeze = false;
        }
    }

    public void ChangeColors(BaseInteractionEventArgs hover)
    {
       
        switch (_idButton)
        {
            case 0:
                {
                    cam.GetComponent<PostProcessLayer>().volumeLayer = LayerMask.GetMask("PostP_Deuteranopia");
                }
                break;
            case 1:
                {
                    cam.GetComponent<PostProcessLayer>().volumeLayer = LayerMask.GetMask("PostP_Protanopia");
                }
                break;
            case 2:
                {
                    cam.GetComponent<PostProcessLayer>().volumeLayer = LayerMask.GetMask("PostP_Tritanopia");
                }
                break;
            case 3:
                {
                    cam.GetComponent<PostProcessLayer>().volumeLayer = LayerMask.GetMask("PostP_Acro");
                }
                break;
            case 4:
                {
                    cam.GetComponent<PostProcessLayer>().volumeLayer = LayerMask.GetMask("Default");
                }
                break;
        }
    }
    public void Freeze(BaseInteractionEventArgs hover)
    {
        if (hover.interactable is XRPokeInteractor)
        {
            freeze = true;
        }
    }
    public void Follow(BaseInteractionEventArgs hover)
    {
        if(hover.interactable is XRPokeInteractor)
        {
            XRPokeInteractor interactor = (XRPokeInteractor)hover.interactorObject;
           
            pokeAttachTransform = interactor.attachTransform;
            offset = visualTarget.position - pokeAttachTransform.position;

            float pokeAngle = Vector3.Angle(offset, visualTarget.TransformDirection(localAxis));
            
            if(pokeAngle < followAngle)
            {
                isFollowing = true;
                freeze = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(freeze)
            return; 
        
        
        if(isFollowing)
        {
            Vector3 localTargetPosition = visualTarget.InverseTransformDirection(pokeAttachTransform.position + offset);
            Vector3 constrainedLocalTargetPsoition = Vector3.Project(localTargetPosition, localAxis);

            visualTarget.position =visualTarget.TransformPoint(constrainedLocalTargetPsoition);
        }
        else
        {
            visualTarget.localPosition = Vector3.Lerp(visualTarget.localPosition, initialLocalPos, Time.deltaTime* resetSpeed);
        }
    }
}
