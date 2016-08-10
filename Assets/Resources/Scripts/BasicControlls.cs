using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
public class BasicControlls : MonoBehaviour {

    public float walkspeed = 1000;
    public float rotationspeed = 100;
    public float maxVelocity = 10;
    public float jumpspeed = 100;
    public readonly float breakConstant = 10;
    public float epsilonY = 5;
    private new Rigidbody rigidbody;


    // Use this for initialization
    void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        float distance = Time.deltaTime * walkspeed;
        Vector3 relativeVelocity = transform.InverseTransformDirection(rigidbody.velocity);
        HandleKeystrokes(distance, rigidbody, relativeVelocity);

        HandleDrag(rigidbody);

    }

    private void HandleDrag(Rigidbody rigidbody) {
        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space) || !groundContact())) {
            rigidbody.drag = breakConstant;
        }
        else {
            rigidbody.drag = 0;
        }
    }

    private void HandleKeystrokes(float distance, Rigidbody rigidbody, Vector3 relativeVelocity) {
        if (Input.GetKeyDown(KeyCode.Space) && groundContact() && relativeVelocity.y < maxVelocity) {
            rigidbody.AddForce(0, jumpspeed, 0);
        }
        if (Input.GetKey(KeyCode.W) && relativeVelocity.z < maxVelocity) {
            Vector3 wc = transform.TransformDirection(new Vector3(0, 0, distance));

            rigidbody.AddForce(ProjectWithStableMagnitude(wc));
        }
        if (Input.GetKey(KeyCode.A) && relativeVelocity.x > -1 * maxVelocity) {
            Vector3 wc = transform.TransformDirection(new Vector3(-distance, 0, 0));

            rigidbody.AddForce(ProjectWithStableMagnitude(wc));
        }
        if (Input.GetKey(KeyCode.D) && relativeVelocity.x < maxVelocity) {
            Vector3 wc = transform.TransformDirection(new Vector3(distance, 0, 0));

            rigidbody.AddForce(ProjectWithStableMagnitude(wc));
        }
        if (Input.GetKey(KeyCode.S) && relativeVelocity.z > -1 * maxVelocity) {
            Vector3 wc = transform.TransformDirection(new Vector3(0, 0, -distance));

            rigidbody.AddForce(ProjectWithStableMagnitude(wc));
        }
    }

    private static Vector3 ProjectWithStableMagnitude(Vector3 wc) {
        Vector3 wcProj = new Vector3(wc.x, 0, wc.z).normalized;
        wcProj.Scale(new Vector3(wc.magnitude, wc.magnitude, wc.magnitude));
        return wcProj;
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