using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SoundRegistry))]
public class AlarmObject : MonoBehaviour {
    public float alarmDelay;
    public float alarmIntesity;
    float alarmCountDown;
    GameObject alarm;
    // Use this for initialization
	void Start () {
        alarmCountDown = alarmDelay;
        alarm = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("InUpdate");
        alarmCountDown -= Time.deltaTime;
        //Debug.Log("Remaining Time: " + alarmCountDown);
        if(alarmCountDown <= 0)
        {
            SoundRegistry.getInstance().addSound(new Sound( alarm, alarmIntesity));
            alarmCountDown = alarmDelay;
        }
	}
}
