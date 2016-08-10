using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PickupObjects : MonoBehaviour {

    //TODO: Raycasting & Portal like behaivour (Ruecke immer wieder in das Zentrum des Sichtfeldes)

    public float throwForce = 1000;
    bool hasPlayer = false;
    bool beingCarried = false;
    private new Rigidbody rigidbody;
    private Rigidbody rigidEtho;
    private Transform cameraTransform;

    void Start() {
        rigidbody = GetComponent<Rigidbody>();
        rigidEtho = (Rigidbody)GameObject.Find("Etho").GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
    }

    void OnTriggerEnter(Collider other) {
        hasPlayer = true;
    }

    void OnTriggerExit(Collider other) {
        hasPlayer = false;
    }

    void Update() {
        if (beingCarried) {
            if (Input.GetMouseButtonDown(0)) {
                rigidbody.isKinematic = false;
                transform.parent = null;
                rigidEtho.mass = rigidEtho.mass - rigidbody.mass;
                beingCarried = false;
                rigidbody.velocity = rigidEtho.velocity;
            }
            else if (Input.GetMouseButtonDown(1)) {
                
                rigidbody.isKinematic = false;
                transform.parent = null;
                rigidEtho.mass = rigidEtho.mass - rigidbody.mass;
                beingCarried = false;
                rigidbody.velocity = rigidEtho.velocity;
                if (Input.GetKey(KeyCode.LeftControl)) {
                    rigidbody.AddForce(cameraTransform.forward * throwForce*3);
                }
                else {
                    rigidbody.AddForce(cameraTransform.forward * throwForce);
                }
            }
        }
        else {
            if (Input.GetMouseButtonDown(0) && hasPlayer) {
                rigidbody.isKinematic = true;
                transform.parent = cameraTransform;
                beingCarried = true;
                rigidEtho.mass = rigidEtho.mass + rigidbody.mass;
            }
        }
    }
}
