using UnityEngine;
using System.Collections;
using System;

public class EyeSwitch  : MonoBehaviour{
    public GameObject eyeDoor;
    public AudioClip soundEffect;
    public float soundIntensity = 10;
    
    public void activateSwitch()
    {
        if(eyeDoor != null)
        {
            eyeDoor.GetComponent<OpeningDoors>().openEyeDoor();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Throwable")
        {
            activateSwitch();
            SoundRegistry.getInstance().addSound(new Sound(this.gameObject, soundIntensity, soundEffect));
        }
    }
}
