using UnityEngine;
public class Sound {

    public static readonly float propagationSpeed = 40;
    private readonly Vector3 sourcePosition;
    private readonly GameObject sourceObject;
    private float radius = 0;
    private float volume;

    public Sound(GameObject sourceObject, float volume) {
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
    /// <para>updates the Sound by changing its radius.</para>
    /// <para>returns wether or not the sound has surpassed its lifetime</para>
    /// <para>if this method returns true the Sound should be discarted</para>
    /// </summary>
    public bool update() {
        radius += propagationSpeed*Time.deltaTime*getCurrentIntensity();
        return radius > volume;
    }

    public float getCurrentRadius() {
        return radius;
    }

    public float getCurrentIntensity() {
        return 1-(radius/volume) ;
    }
}