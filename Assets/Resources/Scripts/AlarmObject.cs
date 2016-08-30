using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SoundRegistry))]
public class AlarmObject : MonoBehaviour {

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
            SoundRegistry.getInstance().addSound(new Sound(this.gameObject, alarmIntesity));
            alarmCountDown = alarmDelay;
        }
	}
}
