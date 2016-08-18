using UnityEngine;
public class Sound {

    public static readonly int propagationSpeed = 3;
    private readonly Vector3 sourcePosition;
    private readonly GameObject sourceObject;
    private float radius = 0;
    private int volume;

    public Sound(GameObject sourceObject, int volume) {
        this.sourceObject = sourceObject;
        this.sourcePosition = sourceObject.transform.position;
        this.volume = volume;
    }
    
    public Vector3 getSourcePosition() {
        return sourcePosition;
    }

    public GameObject getSourceObject() {
        return sourceObject;
    }

    /// <summary>
    /// updates the Sound by changing its radius.
    /// returns wether or not the sound has surpassed its lifetime
    /// </summary>
    public bool update() {
        radius += propagationSpeed;
        return radius > volume;
    }

}