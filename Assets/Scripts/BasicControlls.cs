using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class BasicControlls : MonoBehaviour
{

    public float walkspeed = 10;
    public float rotationspeed = 100;
    public float maxVelocity = 10;
    public float jumpspeed = 100;
    public float heightThreshhold = 0.5f;
    private float epsilonY;




    // Use this for initialization
    void Start()
    {
        CapsuleCollider collider = this.GetComponent<CapsuleCollider>();
        epsilonY = collider.bounds.extents.y + heightThreshhold;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Time.deltaTime * walkspeed;

        if (Input.GetKeyDown(KeyCode.Space) && groundContact())
        {
            transform.Translate(0, distance*jumpspeed, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, distance);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-distance, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -distance);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(distance, 0, 0);
        }


    }

    private static Vector3 ProjectWithStableMagnitude(Vector3 wc)
    {
        Vector3 wcProj = new Vector3(wc.x, 0, wc.z).normalized;
        wcProj.Scale(new Vector3(wc.magnitude, wc.magnitude, wc.magnitude));
        return wcProj;
    }

    bool groundContact()
    {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            float distanceToGround = hit.distance;
            if (distanceToGround <= epsilonY)
            {
                return true;
            }
        }
        return false;
    }
}
