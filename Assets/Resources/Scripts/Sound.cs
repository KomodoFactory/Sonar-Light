using UnityEngine;
public class Sound {

    public static readonly float propagationSpeed = 20;
    public static readonly float minimumVolume = 2;
    private readonly Vector3 sourcePosition;
    private readonly GameObject sourceObject;
    private float radius = 0;
    private float volume;
    private static readonly float fade = 80;
    private float intensityMultiplyer = 1;

    public Sound(GameObject sourceObject, float volume) {
        this.sourceObject = sourceObject;
        this.sourcePosition = sourceObject.transform.position;
        if(volume < minimumVolume)
        {
            volume = minimumVolume;
        }
        if(volume < minimumVolume * 20)
        {
            intensityMultiplyer = volume / (minimumVolume * 20);
        }
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
        float factor = propagationSpeed * Time.deltaTime * getCurrentIntensity();
        if(factor < 0.5f) {
            factor = 0.5f;
        }
        radius += factor;
        return radius > (volume+fade);
    }

    public float getCurrentRadius() {
        return Mathf.Min(radius,volume);
    }

    public float getCurrentIntensity() {
        return (1-(radius/(volume+fade)) )* intensityMultiplyer;
    }
}