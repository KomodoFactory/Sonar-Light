using UnityEngine;
using System.Collections;

public class PromptTrigger : MonoBehaviour {

    public string promtMessage = "PromptMessage";
    public float promtLivetime = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other == GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>())
        {
            ScreenPromptHandler.Instance.DisplayPrompt(promtMessage, 5);
            Destroy(this.gameObject);
        }
    }
}
