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
        Debug.Log("Initialize");
        etho = GameObject.FindGameObjectWithTag("Player");
        playerTransform = etho.transform;
        playerPos = playerTransform.position;
        //playerVel = etho.GetComponent<CharacterMotor>().inputMoveDirection;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Maybe?");
        if (col.gameObject.GetComponent<Rigidbody>() != null)
        {
            Vector3 closestPointPlayer = etho.GetComponent<Collider>().ClosestPointOnBounds(col.transform.position);
            Vector3 closestPointOther = col.ClosestPointOnBounds(playerPos);
            colDir = closestPointOther - closestPointPlayer;
            //Debug.Log("DirVec: " + colDir);
            //Debug.Log("PlayerVel " + playerVel.magnitude);
            Vector3 force = colDir.normalized * collisionForce;
            Debug.Log(force);
            col.gameObject.GetComponent<Rigidbody>().AddRelativeForce(force);
        }
    }

    //void OnCollisionEnter(Collision col)
    //{
    //    Debug.Log("Collisions WOW");
    //    ContactPoint[] colPoints = col.contacts;
    //    foreach (ContactPoint colPoint in colPoints)
    //    {
    //        Vector3 colPointVec = colPoint.point;
    //        if (col.gameObject.GetComponent<Rigidbody>() != null)
    //        {
    //            colDir = colPointVec - playerPos;
    //            Vector3 force = colDir.normalized * 100000;
    //            Debug.Log(force);
    //            col.gameObject.GetComponent<Rigidbody>().AddRelativeForce(colDir.normalized * 100000);
    //        }
    //    }
    //}
}
