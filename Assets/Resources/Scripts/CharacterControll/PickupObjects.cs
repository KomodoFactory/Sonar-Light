using System;
using UnityEngine;

public class PickupObjects : CourserListener
{

    private static readonly string axisPickup = "Fire1";
    private static readonly string axisThrow = "Fire2";
    private static readonly string[] interestedAxis = {axisPickup, axisThrow};

    public float throwForce = 1000;
    private float distanceToObject = 0;
    private float maximumHoveringDistance = 3;
    private bool hasObjectInHand = false;
    private Rigidbody targetObjectRigidbody;
    private GameObject player;
    private Transform cameraTransform;

    public PickupObjects()
    {

    }

    public void initialize()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraTransform = Camera.main.transform;
    }

    public void update()
    {
        if (hasObjectInHand)
        {
            centerObject();
        }
    }

    public bool axisFiered(string axis)
    {

        if (hasObjectInHand)
        {
            if (axis.Equals(axisPickup))
            {
                dropObject();
            }
            else if (axis.Equals(axisThrow))
            {
                throwObject();
            }
            return false;
        }
        if (axis.Equals(axisPickup))
        {
            return true;
        }
        return false;
    }

    public void interactWithFocusedObject(GameObject focusedObject, float distanceToObject)
    {
        if (focusedObject != null && focusedObject.CompareTag("Throwable"))
        {
            targetObjectRigidbody = focusedObject.GetComponent<Rigidbody>();
            this.distanceToObject = Math.Min(distanceToObject, maximumHoveringDistance);
            pickupObject();
        }
    }

    public string[] getInterestedAxes()
    {
        return interestedAxis;
    }

    private void centerObject()
    {
        Vector3 currentPosition = targetObjectRigidbody.worldCenterOfMass;
        Vector3 currentCenter = targetObjectRigidbody.worldCenterOfMass - targetObjectRigidbody.position;
        Vector3 destination = cameraTransform.position + cameraTransform.forward * distanceToObject -currentCenter;
        float distance = Vector3.Distance(currentPosition, destination);
        //TODO:  targetObjectRigidbody.velocity = characterRigidbody.velocity; 
        targetObjectRigidbody.position = Vector3.MoveTowards(currentPosition - currentCenter, destination, Time.deltaTime * distance * 5);
    }

    private void pickupObject()
    {
        targetObjectRigidbody.useGravity = false;
        Physics.IgnoreCollision(player.GetComponent<CapsuleCollider>(), targetObjectRigidbody.GetComponentInParent<Collider>(), true);
        targetObjectRigidbody.angularDrag = 1;
        targetObjectRigidbody.drag = 3;
        hasObjectInHand = true;
    }

    private void throwObject()
    {
        releaseObject();
        targetObjectRigidbody.AddForce(cameraTransform.forward * throwForce);
    }

    private void dropObject()
    {
        releaseObject();
    }

    private void releaseObject()
    {
        hasObjectInHand = false;
        targetObjectRigidbody.useGravity = true;
        targetObjectRigidbody.angularDrag = 0;
        targetObjectRigidbody.drag = 0.05f;
        Physics.IgnoreCollision(player.GetComponent<CapsuleCollider>(), targetObjectRigidbody.GetComponentInParent<Collider>(), false);
    }

    public GameObject getHeldObject()
    {
        return targetObjectRigidbody.gameObject;
    }
}
