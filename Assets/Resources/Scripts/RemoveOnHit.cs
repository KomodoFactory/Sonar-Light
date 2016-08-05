using UnityEngine;
using System.Collections;

public class RemoveOnHit : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
    }
}
