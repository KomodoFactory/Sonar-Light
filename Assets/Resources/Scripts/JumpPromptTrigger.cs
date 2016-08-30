using UnityEngine;
using System.Collections;

public class JumpPromptTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        ScreenPromptHandler.Instance.DisplayPrompt("Press \"Space\" to Jump", 5);
        Destroy(this.gameObject);
    }
}
