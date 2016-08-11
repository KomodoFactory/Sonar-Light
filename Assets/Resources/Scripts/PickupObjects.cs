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

        Vector3 currentPosition = targetObject.position;
        Vector3 destination = cameraTransform.position + cameraTransform.forward * pickupDistance;
        float distance = Vector3.Distance(currentPosition, destination);
        targetObject.velocity = characterRigidbody.velocity;
        targetObject.transform.position = Vector3.MoveTowards(currentPosition, destination, Time.deltaTime * distance * 5);

    }

    private void pickupObject() {
        targetObject.useGravity = false;
        Physics.IgnoreCollision((Collider)this.GetComponent<Collider>(), (Collider)targetObject.GetComponent<Collider>(), true);
        targetObject.angularDrag = 1;
        targetObject.drag = 3;
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
        targetObject.angularDrag = 0;
        targetObject.drag = 0.05f;
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
