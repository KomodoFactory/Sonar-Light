using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class SoundOnImpact : MonoBehaviour {

    public float velocityMultiplier = 2;
    public float velocityThreshhold = 1;
    public AudioClip audioclip;
    private GameObject thrown;
    private float velMag;
    private static readonly float soundCooldown = 0.2f;
    private float soundCooldownValue = 0;

	// Use this for initialization
	void Start () {
        thrown = this.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        soundCooldownValue -= Time.deltaTime;
	}

    void OnCollisionEnter(Collision col)
    {
        velMag = col.relativeVelocity.magnitude;
        if (!(col.gameObject.tag.Contains("Player")))
        {
            if (velMag > velocityThreshhold && velMag > 0)
            {
                if (soundCooldownValue < 0)
                {
                    SoundRegistry.getInstance().addSound(new Sound(thrown, velMag * velocityMultiplier,audioclip));
                    soundCooldownValue = soundCooldown;
                }
            }
        }
        /*SoundOnImpact[] childScripts = this.gameObject.GetComponentsInChildren<SoundOnImpact>();
        if (childScripts.Length < 0) {
            for(int i = 0;i< childScripts.Length; i++) {
                childScripts[i].OnCollisionEnter(col);
            }
        }*/

    }

}
