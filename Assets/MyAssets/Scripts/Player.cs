using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //UI

    public PickAndDrop pad;

    [SerializeField]
    public GameObject GrabUI;
    public GameObject DropUI;

    private void Update()
    {
        if (Physics.Raycast(pad.playerCameraTransform.position, pad.playerCameraTransform.forward, out RaycastHit raycastHit, pad.pickupDistance, pad.pickUpLayerMask))
        {
            if (pad.objectGrabbable == null)
            {
                //Grab
                GrabUI.SetActive(true);
                DropUI.SetActive(false);
            }
            else
            {
                //Drop
                GrabUI.SetActive(false);
                DropUI.SetActive(true);
            }
            
        }
        else
        {
            //No interaction at all
            GrabUI.SetActive(false);
            DropUI.SetActive(false);
        }
    }
}
