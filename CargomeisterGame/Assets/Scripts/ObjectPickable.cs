using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPickable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectPickTransform;

    private void OnEnable()
    {
         EventManager.eDrop += Drop;
    }
    private void OnDisable()
    {
        EventManager.eDrop -= Drop;
    }


    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }
    public void Pick(Transform objectPickTransform)
    {
        this.objectPickTransform = objectPickTransform;
        objectRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        objectRigidbody.useGravity = false;
    }

    public void Drop(object sender, EventArgs e)
    {
        this.objectPickTransform = null;
        objectRigidbody.useGravity = true;
        float forceSpeed = 10f;
        objectRigidbody.AddForce(PlayerCharacterController.Instance.playerCamera.transform.forward * forceSpeed, ForceMode.Impulse);
        objectRigidbody.constraints = RigidbodyConstraints.None;
    }

    private void FixedUpdate()
    {
        if(objectPickTransform != null)
        {
            objectRigidbody.MovePosition(objectPickTransform.position);
            float lerpSpeed = 30f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectPickTransform.position, Time.deltaTime * lerpSpeed);
            GetComponent<Animation>().Stop();
            objectRigidbody.MovePosition(newPosition);
        }
    }


}
