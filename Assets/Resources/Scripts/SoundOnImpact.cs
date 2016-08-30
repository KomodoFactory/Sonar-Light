using UnityEngine;
using System.Collections;

public class SoundOnImpact : MonoBehaviour {

    public float velocityMultiplier;
    public float velocityThreshhold;
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
            if (velMag > velocityThreshhold)
                //Debug.Log("Sound!");
                SoundRegistry.getInstance().addSound(new Sound(thrown, velMag * velocityMultiplier));
        }
    }

}
