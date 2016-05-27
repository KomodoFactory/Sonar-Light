using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class BasicControlls : MonoBehaviour {

    public float walkspeed = 500;
    public float rotationspeed = 100;
    public float maxVelocity = 10;
    public float jumpspeed = 100;
    private float epsilonY;


    // Use this for initialization
    void Start() {
        CapsuleCollider col = GetComponent<CapsuleCollider>();
        epsilonY = col.bounds.extents.y;
    }

    // Update is called once per frame
    void Update() {
        float distance = Time.deltaTime * walkspeed;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Vector3 relativeVelocity = transform.InverseTransformDirection(rigidbody.velocity);

        if (Input.GetKeyDown(KeyCode.Space) && groundContact() && relativeVelocity.y < maxVelocity) {
            rigidbody.AddForce(0, jumpspeed, 0);
        }
        if (Input.GetKey(KeyCode.W) && relativeVelocity.z < maxVelocity) {
            rigidbody.AddRelativeForce(0, 0, distance);
        }
        if (Input.GetKey(KeyCode.A) && relativeVelocity.x > -1 * maxVelocity) {
            rigidbody.AddForce(distance * -1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D) && relativeVelocity.x < maxVelocity) {
            rigidbody.AddForce(distance, 0, 0);
        }
        if (Input.GetKey(KeyCode.S) && relativeVelocity.z > -1 * maxVelocity) {
            rigidbody.AddForce(0, 0, distance * -1);
        }

    }

    bool groundContact() {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -Vector3.up, out hit)) {
            float distanceToGround = hit.distance;
            if (distanceToGround <= epsilonY) {
                return true;
            }
        }
        return false;
    }
}
