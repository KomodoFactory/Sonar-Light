using UnityEngine;
using System.Collections;

public class TempPleaseDelete : MonoBehaviour {

    Transform mainCam;

	// Use this for initialization
	void Start () {
        mainCam = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Temp_Transform: "+mainCam.forward);
	}
}
