using UnityEngine;
using UnityStandardAssets.ImageEffects;

[RequireComponent(typeof(Camera))]
public class DeveloperCommands : MonoBehaviour
{

    //private EdgeDetectionColor edgeScript;
    private new Camera camera;
    public int nearModeCliping = 30;
    public int farModeClipping = 1000;
    private int[] POVs= {60,70,90,100,120};
    private int POVpointer = 0;

    // Use this for initialization
    void Start()
    {
        camera = this.GetComponent<Camera>();
        //edgeScript = this.GetComponent<EdgeDetectionColor>();
        //edgeScript.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            //edgeScript.enabled = !edgeScript.enabled;
            Debug.Log("Have a good day, Sir!");
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            if (camera.farClipPlane == nearModeCliping)
            {
                camera.farClipPlane = farModeClipping;
            }
            else
            {
                camera.farClipPlane = nearModeCliping;
            }
        }

        if (Input.GetKeyDown(KeyCode.F10))
        {
            camera.fieldOfView = POVs[POVpointer];
            POVpointer++;
            POVpointer = POVpointer % POVs.Length;
        }
    }
}
