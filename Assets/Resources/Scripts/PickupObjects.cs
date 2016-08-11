using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickupObjects : MonoBehaviour {

    //TODO: Raycasting & Portal like behaivour (Ruecke immer wieder in das Zentrum des Sichtfeldes)

    public float throwForce = 1000;
    public float pickupDistance = 5;
    Rigidbody targetObject;
    bool hasObjectInHand = false;
    Transform cameraTransform;
    Rigidbody characterRigidbody;

    void Start() {
        cameraTransform = Camera.main.transform;
        characterRigidbody = (Rigidbody)GetComponent<Rigidbody>();
    }

    void Update() {

        if (hasObjectInHand) {
            if (Input.GetMouseButtonDown(0)) {
                dropObject();
            }
            else if (Input.GetMouseButtonDown(1)) {
                throwObject();
            }
        }
        else {
            if (Input.GetMouseButtonDown(0)) {
                targetObject = getObjectInRange();
                if (targetObject != null) {
                    pickupObject();
                }
            }
        }
    }

    private void pickupObject() {
        targetObject.transform.parent = cameraTransform;
        targetObject.isKinematic = true;
        hasObjectInHand = true;
    }

    private void throwObject() {
        releaseObject();
        targetObject.AddForce(cameraTransform.forward * throwForce);
    }

    private void dropObject() {
        releaseObject();
    }

    private void releaseObject() {
        hasObjectInHand = false;
        targetObject.transform.parent = null;
        targetObject.isKinematic = false;
        targetObject.velocity = characterRigidbody.velocity;
    }

    Rigidbody getObjectInRange() {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit)) {
            float distance = hit.distance;
            if (distance <= pickupDistance && hit.collider.CompareTag("Throwable")) {
                return hit.collider.GetComponentInParent<Rigidbody>();
            }
        }
        return null;
    }
}
