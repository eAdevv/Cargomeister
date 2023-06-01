using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickUpDrop : MonoBehaviour
{
    [SerializeField]private Transform playerCameraTransform;
    [SerializeField]private Transform objectPickTransform;
    [SerializeField]private LayerMask PickUpObj;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            float pickUpDistance = 2f;
            if(Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, PickUpObj))
            {
                if(raycastHit.transform.TryGetComponent(out ObjectPickable objectPickable))
                {
                    objectPickable.Pick(objectPickTransform);
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            EventManager.OnDrop();
        }

       
    }
}
