using UnityEngine;
using System.Collections;

public class CharacterMotorMovement
{
    public float maxForwardSpeed = 3.0f;
    public float maxSidewaysSpeed = 2.0f;
    public float maxBackwardsSpeed = 2.0f;

    public AnimationCurve slopeSpeedMultiplier = new AnimationCurve(new Keyframe(-90, 1), new Keyframe(0, 1), new Keyframe(90, 0));

    public float maxGroundAcceleration = 50.0f;
    public float maxAirAcceleration = 20.0f;

    public float gravity = 9.81f;
    public float maxFallSpeed = 20.0f;

    public CollisionFlags collisionFlags;

    public Vector3 velocity;
    public Vector3 frameVelocity = Vector3.zero;

    public Vector3 hitPoint = Vector3.zero;
    public Vector3 lastHitPoint = new Vector3(Mathf.Infinity, 0, 0);
}