using UnityEngine;
using System.Collections.ObjectModel;

public class MaterialHandler : MonoBehaviour {

    public Material nonShaderMaterial;
    public Material shaderMaterial;
    private static MaterialHandler instance;

    private MaterialHandler() { }

    public static MaterialHandler getInstance() {
        if (instance == null) {
            instance = GameObject.FindGameObjectWithTag("Console").GetComponent<MaterialHandler>();
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

        float[] distances = new float[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        float[] intensities = new float[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        Vector4[] soundSources = new Vector4[10];

        for(int i = 0;i< soundSources.Length; i++)
        {
            soundSources[i] = new Vector4(0,0,0,0);
        }

        for (int i = 0; i < sounds.Length; i++) {
            distances[i] = sounds[i].getCurrentRadius();
            intensities[i] = sounds[i].getCurrentIntensity();
            soundSources[i] = sounds[i].getSourcePosition();
        }
        shaderMaterial.SetFloatArray("_Distances", distances);
        shaderMaterial.SetFloatArray("_Intensities",intensities);
        shaderMaterial.SetVectorArray("_SoundSources", soundSources);

    }
}
