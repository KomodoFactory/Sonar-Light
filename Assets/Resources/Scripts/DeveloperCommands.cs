using UnityEngine;
using UnityStandardAssets.ImageEffects;

[RequireComponent(typeof(Camera))]
public class DeveloperCommands : MonoBehaviour
{

    private EdgeDetectionColor edgeScript;
    private new Camera camera;
    public int nearModeCliping = 30;
    public int farModeClipping = 1000;
    private int[] POVs= {60,70,90,100,120};
    private int POVpointer = 0;

    // Use this for initialization
    void Start()
    {
        camera = this.GetComponent<Camera>();
        edgeScript = this.GetComponent<EdgeDetectionColor>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F10))
        {
            camera.fieldOfView = POVs[POVpointer];
            POVpointer++;
            POVpointer = POVpointer % POVs.Length;
        }
        if (Input.GetKeyDown(KeyCode.F9))
        {
            ScreenPromptHandler.Instance.DisplayPrompt("Hallo", 10);
        }
    }
}
