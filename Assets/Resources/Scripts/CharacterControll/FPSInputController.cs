using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Require a character controller to be attached to the same game object
[RequireComponent(typeof(CharacterMotor))]
[AddComponentMenu("Character/FPS Input Controller")]

public class FPSInputController : MonoBehaviour {
    private CharacterMotor motor;
    private float directionLength;
    public float footstepFrequency = 0.6f;
    private float lastFootstepSound = 0f;

    void Awake() {
        motor = GetComponent<CharacterMotor>();
    }

    void Update() {
        Vector3 directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        lastFootstepSound += Time.deltaTime;

        if (directionVector != Vector3.zero) {
            if (lastFootstepSound > footstepFrequency) {
                SoundRegistry.getInstance().addSound(new Sound(gameObject, 20));
                lastFootstepSound = 0;
            }

            directionVector = normalizeVector(directionVector);
            modifyLengthForSensitivControlles();
            directionVector = directionVector * directionLength;
        }

        motor.inputMoveDirection = transform.rotation * directionVector;
        motor.inputJump = Input.GetButton("Jump");
    }

    private Vector3 normalizeVector(Vector3 directionVector) {
        directionLength = directionVector.magnitude;
        return directionVector / directionLength;
    }

    private void modifyLengthForSensitivControlles() {
        directionLength = Mathf.Min(1.0f, directionLength);
        directionLength = directionLength * directionLength;
    }

}