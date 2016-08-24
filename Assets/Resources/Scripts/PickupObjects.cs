using System;
using UnityEngine;

public class PickupObjects : MonoBehaviour {

    public float throwForce = 1000;
    public float pickupDistance = 5;
    private Rigidbody targetObjectRigidbody;
    private bool hasObjectInHand = false;
    private Transform cameraTransform;
    private AxisHandler axisPickup;
    private AxisHandler axisThrow;
    private GameObject player;
    void Start() {
        cameraTransform = Camera.main.transform;
        player = GameObject.FindGameObjectsWithTag("Player")[0];

        axisPickup = new AxisHandler("Fire1");
        axisThrow = new AxisHandler("Fire2");
    }

    void Update() {

        axisPickup.Update();
        axisThrow.Update();

        if (hasObjectInHand) {
            centerObject();
            if (axisPickup.pressedDown()) {
                dropObject();
            }
            else if (axisThrow.pressedDown()) {
                throwObject();
            }
        }
        else {
            if (axisPickup.pressedDown()) {
                targetObjectRigidbody = getObjectInRange();
                if (targetObjectRigidbody != null) {
                    pickupObject();
                }
            }
        }
    }

    private void centerObject() {

        Vector3 currentPosition = targetObjectRigidbody.position;
        Vector3 destination = cameraTransform.position + cameraTransform.forward * pickupDistance;
        float distance = Vector3.Distance(currentPosition, destination);
      //  targetObjectRigidbody.velocity = characterRigidbody.velocity;    
        targetObjectRigidbody.transform.position = Vector3.MoveTowards(currentPosition, destination, Time.deltaTime * distance * 5);

    }

    private void pickupObject() {
        targetObjectRigidbody.useGravity = false;
        Physics.IgnoreCollision(player.GetComponent<CapsuleCollider>(),targetObjectRigidbody.GetComponentInParent<Collider>(), true);
        targetObjectRigidbody.angularDrag = 1;
        targetObjectRigidbody.drag = 3;
        hasObjectInHand = true;
    }

    private void throwObject() {
        releaseObject();
        targetObjectRigidbody.AddForce(cameraTransform.forward * throwForce);
    }

    private void dropObject() {
        releaseObject();
    }

    private void releaseObject() {
        hasObjectInHand = false;
        targetObjectRigidbody.useGravity = true;
        targetObjectRigidbody.angularDrag = 0;
        targetObjectRigidbody.drag = 0.05f;
        Physics.IgnoreCollision(player.GetComponent<CapsuleCollider>(), targetObjectRigidbody.GetComponentInParent<Collider>(), false);
        Debug.Log("collider:" + targetObjectRigidbody.GetComponentInParent<Collider>() + player.GetComponent<CapsuleCollider>());
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

    public GameObject getHeldObject() {
        if(targetObjectRigidbody != null) {
            return targetObjectRigidbody.gameObject;
        }else {
            return null;
        }
    }
}
