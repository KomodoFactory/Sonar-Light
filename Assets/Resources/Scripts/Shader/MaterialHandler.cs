using UnityEngine;
using UnityEngine.VR;

public class MaterialHandler : MonoBehaviour {

    public Material nonShaderMaterial;
    public Material shaderMaterial;
    private static MaterialHandler instance;
    private static float intensityMultiplier = 1;

    private MaterialHandler() { }

    public static MaterialHandler getInstance() {
        if (instance == null) {
            instance = GameObject.FindGameObjectWithTag("Console").GetComponent<MaterialHandler>();
            if (!isOculusPresent()) {
                intensityMultiplier = 10;
            }
        }
        return instance;
    }

    public bool switchMaterial(Renderer renderer) {
        if (renderer.sharedMaterial == nonShaderMaterial) {
            renderer.sharedMaterial = shaderMaterial;
            return true;
        }
        else {
            renderer.sharedMaterial = nonShaderMaterial;
            return false;
        }
    }

    public void setShaderData(Sound[] sounds) {

        float[] distances = new float[SoundRegistry.queueSize];
        float[] intensities = new float[SoundRegistry.queueSize];
        Vector4[] soundSources = new Vector4[SoundRegistry.queueSize];
        float[] waveRadii = new float[SoundRegistry.queueSize];

        for (int i = 0; i < sounds.Length; i++) {
            distances[i] = sounds[i].getCurrentRadius();
            intensities[i] = sounds[i].getCurrentIntensity() * intensityMultiplier;
            soundSources[i] = sounds[i].getSourcePosition();
            waveRadii[i] = sounds[i].getWaveRadius();
        }

        shaderMaterial.SetFloatArray("_Distances", distances);
        shaderMaterial.SetFloatArray("_Intensities", intensities);
        shaderMaterial.SetVectorArray("_SoundSources", soundSources);
        shaderMaterial.SetFloatArray("_WaveRadius", waveRadii);
    }

    public static float getIntensityMultiplier() {
        return intensityMultiplier;
    }
    public static void setIntensityMultiplier(float intensity) {
        intensityMultiplier = intensity;
    }

    private static bool isOculusPresent() {
        return UnityEngine.XR.XRDevice.isPresent;
    }
}
