using UnityEngine;
using System.Collections;

public class AlarmObject : MonoBehaviour {

    public AudioClip audioclip;
    public float alarmDelay;
    public float alarmIntesity;
    float alarmCountDown;

    // Use this for initialization
	void Start () {
        alarmCountDown = alarmDelay;
	}
	
	// Update is called once per frame
	void Update () {
        alarmCountDown -= Time.deltaTime;
        if(alarmCountDown <= 0)
        {
            SoundRegistry.getInstance().addSound(new Sound(this.gameObject, alarmIntesity, audioclip));
            alarmCountDown = alarmDelay;
        }
	}
}
