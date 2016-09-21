using UnityEngine;
using System.Collections;

public class CharacterCollision : MonoBehaviour {

    public float collisionForce = 100;
    private GameObject etho;
    private Transform playerTransform;
    private Vector3 playerPos;
    private Vector3 colDir;
    
    void Start() {
        etho = GameObject.FindGameObjectWithTag("Player");
        playerTransform = etho.transform;
        playerPos = playerTransform.position;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<Rigidbody>() != null)
        {
            Vector3 closestPointPlayer = etho.GetComponent<Collider>().ClosestPointOnBounds(col.transform.position);
            Vector3 closestPointOther = col.ClosestPointOnBounds(playerPos);
            colDir = closestPointOther - closestPointPlayer;
            Vector3 force = colDir.normalized * collisionForce;
            col.gameObject.GetComponent<Rigidbody>().AddRelativeForce(force);
        }
    }
}
