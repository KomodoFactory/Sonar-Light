using UnityEngine;
using System.Collections;

public class CameraForwardProvider : MonoBehaviour {

    public static Vector3 mainCameraForward;
    public static Vector3 mainCameraPosition;
    public static Quaternion mainCameraRotation;
    public static Transform mainCameraTransform;
    private static Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        mainCameraForward = mainCamera.transform.forward;
        mainCameraPosition = mainCamera.transform.position;
        mainCameraRotation = mainCamera.transform.rotation;
        mainCameraTransform = mainCamera.transform;
    }

	void Update () {
        mainCameraForward = mainCamera.transform.forward;
        mainCameraPosition = mainCamera.transform.position;
        mainCameraRotation = mainCamera.transform.rotation;
        mainCameraTransform = mainCamera.transform;
    }

}
