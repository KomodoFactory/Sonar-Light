using UnityEngine;
using System.Collections;

public class BasicMouseLook : MonoBehaviour {

    public Vector2 targetDirection;
    //public Vector2 targetCharacterDirection;
    public Vector2 clampInDegrees = new Vector2(360, 180);
    public float rotationspeed = 10;

    void Start()
    {
        // Set target direction to the camera's initial orientation.
        targetDirection = transform.localRotation.eulerAngles;

        // Set target direction for the character body to its inital state.
        //if (characterBody) targetCharacterDirection = characterBody.transform.localRotation.eulerAngles;
    }

    // Update is called once per frame
    void Update () {

        var targetOrientation = Quaternion.Euler(targetDirection);
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDelta.x = Mathf.Clamp(mouseDelta.x, -clampInDegrees.x * 0.5f, clampInDegrees.x * 0.5f);
        var xRotation = Quaternion.AngleAxis(-mouseDelta.y, targetOrientation * Vector3.right);
        transform.localRotation = xRotation;

        mouseDelta.y = Mathf.Clamp(mouseDelta.y, -clampInDegrees.y * 0.5f, clampInDegrees.y * 0.5f);
        transform.localRotation *= targetOrientation;
        var yRotation = Quaternion.AngleAxis(mouseDelta.x, transform.InverseTransformDirection(Vector3.up));
        transform.localRotation *= yRotation;
    }
}
