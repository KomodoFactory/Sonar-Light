using UnityEngine;
using System.Collections;

public class Impact_Test_Script : MonoBehaviour {

    
    bool show = true;
    public GameObject destroyMe;

	void Start () {
        
	}
	
	void Update () {
        if (show) {
            ScreenPromptHandler.Instance.DisplayPrompt("F8 to Start", 4);
            show = false;
        }
        if (Input.GetKeyDown(KeyCode.F8)) {
            GameObject.Destroy(destroyMe);
            GetComponent<Rigidbody>().isKinematic = false;
        }


	
	}
}
