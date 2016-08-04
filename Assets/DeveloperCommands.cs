using UnityEngine;
using UnityStandardAssets.ImageEffects;

[RequireComponent(typeof(Camera))]
public class DeveloperCommands : MonoBehaviour
{

    private EdgeDetectionColor edgeScript;
    private new Camera camera;
    public int nearModeCliping = 30;
    public int farModeClipping = 1000;

    // Use this for initialization
    void Start()
    {
        camera = this.GetComponent<Camera>();
        edgeScript = this.GetComponent<EdgeDetectionColor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            edgeScript.enabled = !edgeScript.enabled;
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
    }
}
