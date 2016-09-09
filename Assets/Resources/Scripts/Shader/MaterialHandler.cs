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
            if (!isOcculusPresent()) {
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

        for (int i = 0; i < sounds.Length; i++) {
            distances[i] = sounds[i].getCurrentRadius();
            intensities[i] = sounds[i].getCurrentIntensity() * intensityMultiplier;
            soundSources[i] = sounds[i].getSourcePosition();
        }

        shaderMaterial.SetFloatArray("_Distances", distances);
        shaderMaterial.SetFloatArray("_Intensities",intensities);
        shaderMaterial.SetVectorArray("_SoundSources", soundSources);

    }

    public static float getMinimalIntensity()
    {
        return intensityMultiplier;
    }
    public static void setMinimalIntensity(float intensity)
    {
        intensityMultiplier = intensity;
    }

    private static bool isOcculusPresent() {
        return VRDevice.isPresent;
    }
}
