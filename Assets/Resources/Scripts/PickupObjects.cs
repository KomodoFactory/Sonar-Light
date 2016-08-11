using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickupObjects : MonoBehaviour {

    public float throwForce = 1000;
    public float pickupDistance = 5;
    private Rigidbody targetObject;
    private bool hasObjectInHand = false;
    private Transform cameraTransform;
    private Rigidbody characterRigidbody;

    void Start() {
        cameraTransform = Camera.main.transform;
        characterRigidbody = (Rigidbody)GetComponent<Rigidbody>();
    }

    void Update() {

        if (hasObjectInHand) {
            centerObject();
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

    private void centerObject() {

        float distance = Vector3.Distance(targetObject.position, cameraTransform.position);

        targetObject.transform.position = Vector3.Lerp(targetObject.transform.position, cameraTransform.position + cameraTransform.forward * pickupDistance, Time.deltaTime * distance);

    }

    private void pickupObject() {
        targetObject.useGravity = false;
        Physics.IgnoreCollision((Collider)this.GetComponent<Collider>(), (Collider)targetObject.GetComponent<Collider>(), true);
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
        targetObject.useGravity = true;
        Physics.IgnoreCollision((Collider)this.GetComponent<Collider>(), (Collider)targetObject.GetComponent<Collider>(), false);
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
