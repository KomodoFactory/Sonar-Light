using UnityEngine;
using System.Collections;

public class CameraForwardProvider : MonoBehaviour {

    public static Vector3 mainCameraForward;
    public static Vector3 mainCameraPosition;
    private static Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        mainCameraForward = mainCamera.transform.forward;
        mainCameraPosition = mainCamera.transform.position;
    }

	void Update () {
        mainCameraForward = mainCamera.transform.forward;
        mainCameraPosition = mainCamera.transform.position;
	}
}
