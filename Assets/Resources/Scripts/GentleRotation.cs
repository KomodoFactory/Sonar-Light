using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
public class GentleRotation : MonoBehaviour {

    void Update()
    {
        transform.Rotate(Vector3.forward , Time.deltaTime * 100);
    }
}
