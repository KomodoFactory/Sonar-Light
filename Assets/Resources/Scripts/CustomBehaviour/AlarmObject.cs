using UnityEngine;
using System.Collections;

public class AlarmObject : MonoBehaviour {

    public AudioClip audioclip1;
    public AudioClip audioclip2;
    public float alarmDelay;
    public float alarmIntesity;
    float alarmCountDown;
    private bool firstSound = true;

    // Use this for initialization
	void Start () {
        alarmCountDown = alarmDelay;
	}
	
	// Update is called once per frame
	void Update () {
        alarmCountDown -= Time.deltaTime;
        if(alarmCountDown <= 0)
        {
            if (firstSound)
            {
                SoundRegistry.getInstance().addSound(new Sound(this.gameObject, alarmIntesity, audioclip1));
            }
            else
            {
                SoundRegistry.getInstance().addSound(new Sound(this.gameObject, alarmIntesity, audioclip2));
            }
            firstSound = !firstSound;
            alarmCountDown = alarmDelay;
        }
	}
}
