﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class SoundOnImpact : MonoBehaviour {

    public float velocityMultiplier = 2;
    public float velocityThreshhold = 1;
    public AudioClip audioclip;
    private GameObject thrown;
    private Rigidbody thrownRB;
    private float velMag;
    private static readonly float soundCooldown = 0.2f;
    private float soundCooldownValue = 0;

	// Use this for initialization
	void Start () {
        thrown = this.gameObject;
        thrownRB = thrown.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        soundCooldownValue -= Time.deltaTime;
	}

    void OnTriggerEnter(Collider col)
    {
        velMag = thrownRB.velocity.magnitude;
        //Debug.Log(velMag);
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
    }

}