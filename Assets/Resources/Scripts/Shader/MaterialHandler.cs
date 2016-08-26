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
        Debug.Log("Shader: " + shaderMaterial);
        Debug.Log("Nonshader: " + nonShaderMaterial);

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


        for (int i = 0; i < sounds.Length; i++) {
            shaderMaterial.SetVector("_SoundSources"+i, sounds[i].getSourcePosition());
            shaderMaterial.SetFloat("_Distances"+i,sounds[i].getCurrentRadius());

        }
    }
}
