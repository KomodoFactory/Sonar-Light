using UnityEngine;
using UnityEngine.VR;

public class ResetOcculus : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F7))
        {
            UnityEngine.VR.InputTracking.Recenter();
        }
    }
}
