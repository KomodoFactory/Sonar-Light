using UnityEngine;
using System.Collections;


[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]
public class BasicControlls : MonoBehaviour {

    public float walkspeed = 500;
    public float rotationspeed = 100;
    public float maxVelocity = 10;
    public float maxJumpVelocity = 15;
    public float jumpspeed = 500;
    private float epsilonY = 0f;


    // Use this for initialization
    void Start () {
        CapsuleCollider col = GetComponent<CapsuleCollider>();
        epsilonY = (col.height / 2);
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody rb = GetComponent<Rigidbody>();
        float distance = 0;
        Vector3 relVel = transform.InverseTransformDirection(rb.velocity);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            {
                var distanceToGround = hit.distance;
                if (distanceToGround <= epsilonY)
                {
                    if(relVel.y < maxVelocity)
                        rb.AddRelativeForce(0, jumpspeed, 0);
                }
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (relVel.z < maxVelocity)
            {
                distance = walkspeed;
                distance *= Time.deltaTime;
                rb.AddRelativeForce(0, 0, distance);
            }
        }
        if(Input.GetKey(KeyCode.A))
        {
            if(relVel.x > -1 * maxVelocity)
            { 
                distance = walkspeed;
                distance *= Time.deltaTime;
                rb.AddRelativeForce(distance * -1, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (relVel.x < maxVelocity)
            {
                distance = walkspeed;
                distance *= Time.deltaTime;
                rb.AddRelativeForce(distance, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (relVel.z > -1 * maxVelocity)
            {
                distance = walkspeed;
                distance *= Time.deltaTime;
                rb.AddRelativeForce(0, 0, distance * -1);
            }
        }
	}
}
