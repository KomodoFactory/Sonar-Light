using UnityEngine;
using System.Collections;

public class RemoveOnHit : MonoBehaviour {

    private new BoxCollider collider;

    void Start() {
        collider = GetComponent<BoxCollider>();
    }
   
    void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
    }
}
