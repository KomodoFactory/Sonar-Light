using UnityEngine;

[ExecuteInEditMode]
public class AmazingShaderScript : MonoBehaviour {

    public Material material;

    void OnRenderImage(RenderTexture source, RenderTexture destination) {


        Graphics.Blit(source,destination,material);

    }

}
