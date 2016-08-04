using UnityEngine;
using UnityStandardAssets.ImageEffects;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Camera))]
public class BasicControlls : MonoBehaviour {

    public float walkspeed = 500;
    public float rotationspeed = 100;
    public float maxVelocity = 10;
    public float jumpspeed = 100;
    public float heightThreshhold=0.5f;
    private float epsilonY;
    private EdgeDetectionColor edgeScript;
    private new Camera camera;
    public int nearModeCliping = 30;
    public int farModeClipping = 1000;


    // Use this for initialization
    void Start() {
        CapsuleCollider collider = this.GetComponent<CapsuleCollider>();
        epsilonY = collider.bounds.extents.y + heightThreshhold;
        edgeScript = this.GetComponent<EdgeDetectionColor>();
        camera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        float distance = Time.deltaTime * walkspeed;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Vector3 relativeVelocity = transform.InverseTransformDirection(rigidbody.velocity);

        if (Input.GetKeyDown(KeyCode.F11)) {
            edgeScript.enabled = !edgeScript.enabled;
        }
        if (Input.GetKeyDown(KeyCode.F5)) {
            if(camera.farClipPlane == nearModeCliping) {
                camera.farClipPlane = farModeClipping;
            }else {
                camera.farClipPlane = nearModeCliping;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && groundContact() && relativeVelocity.y < maxVelocity) {
            rigidbody.AddForce(0, jumpspeed, 0);
        }
        if (Input.GetKey(KeyCode.W) && relativeVelocity.z < maxVelocity) {
            Vector3 wc = transform.TransformDirection(new Vector3(0, 0, distance));

            rigidbody.AddForce(ProjectWithStableMagnitude(wc));
        }
        if (Input.GetKey(KeyCode.A) && relativeVelocity.x > -1 * maxVelocity) {
            Vector3 wc = transform.TransformDirection(new Vector3(-distance, 0, distance));

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
