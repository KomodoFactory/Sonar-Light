using UnityEngine;
using System.Collections;

public class CharacterCollision : MonoBehaviour {

    public float collisionForce = 100;
    GameObject etho;
    Transform playerTransform;
    Vector3 playerPos;
    //Vector3 playerVel;
    Vector3 colDir;
    // Use this for initialization
    void Start() {
        etho = GameObject.FindGameObjectWithTag("Player");
        playerTransform = etho.transform;
        playerPos = playerTransform.position;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<Rigidbody>() != null)
        {
            Vector3 closestPointPlayer = etho.GetComponent<Collider>().ClosestPointOnBounds(col.transform.position);
            Vector3 closestPointOther = col.ClosestPointOnBounds(playerPos);
            colDir = closestPointOther - closestPointPlayer;
            Vector3 force = colDir.normalized * collisionForce;
            //Debug.Log(force);
            col.gameObject.GetComponent<Rigidbody>().AddRelativeForce(force);
        }
    }
}
