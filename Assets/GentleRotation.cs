using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
public class GentleRotation : MonoBehaviour {

    private new Rigidbody rigidbody;

    // Use this for initialization
    void Start () {
        rigidbody = this.GetComponent<Rigidbody>();
       
	}

    void Update()
    {
        transform.Rotate(Vector3.forward , Time.deltaTime * 100);

        //rigidbody.AddRelativeTorque(new Vector3(0,0,50));
       // rigidbody.MoveRotation(new Quaternion(4, 4, 4, 4));
    }
}
