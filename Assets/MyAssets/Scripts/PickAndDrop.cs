using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAndDrop : MonoBehaviour
{
    [SerializeField] public Transform playerCameraTransform;
    [SerializeField] public Transform objectGrabPointTransform;
    [SerializeField] public LayerMask pickUpLayerMask;

    public ObjectGrabbable objectGrabbable;
    public float pickupDistance = 2f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabbable == null)
            {
                //Grab  
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, pickUpLayerMask))
                {
                    //Debug.Log(raycastHit.transform); Thank god it's finally working
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                        //Debug.Log(objectGrabbable); IT'S FINALLY WORKING WE'RE SO BACK
                    }
                }
            }
            else
            {
                //Drop
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }
    }
}
