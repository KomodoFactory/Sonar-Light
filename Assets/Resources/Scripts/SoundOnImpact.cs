using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class SoundOnImpact : MonoBehaviour {

    public float velocityMultiplier = 5;
    public float velocityThreshhold = 1;
    GameObject thrown;
    Rigidbody thrownRB;
    float velMag;

	// Use this for initialization
	void Start () {
        thrown = this.gameObject;
        thrownRB = thrown.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        velMag = thrownRB.velocity.magnitude;
        //Debug.Log(velMag);
        if (!(col.gameObject.tag.Contains("Player")))
        {
            if (velMag > velocityThreshhold && velMag > 0)
                //Debug.Log("Sound!");
                SoundRegistry.getInstance().addSound(new Sound(thrown, velMag * velocityMultiplier));
        }
    }

}
