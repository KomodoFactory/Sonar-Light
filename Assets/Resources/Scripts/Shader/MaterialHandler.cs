using UnityEngine;
using System.Collections.Generic;

public class MaterialHandler : MonoBehaviour
{

    public Material nonShaderMaterial;
    public Material ShaderMaterial;
    private static MaterialHandler instance;

    private MaterialHandler() { }

    public static MaterialHandler getInstance()
    {
        if (instance == null)
        {
            instance = GameObject.FindGameObjectWithTag("Console").GetComponent<MaterialHandler>();
        }
        return instance;
    }

    public bool switchMaterial(Renderer renderer)
    {
        Debug.Log("Shader: " + ShaderMaterial);
        Debug.Log("Nonshader: " + nonShaderMaterial);

        if (renderer.sharedMaterial == nonShaderMaterial)
        {
            renderer.sharedMaterial = ShaderMaterial;
            return true;
        }
        else
        {
            renderer.sharedMaterial = nonShaderMaterial;
            return false;
        }
    }

    public void setShaderData(List<Sound> sounds)
    {

    }
}
