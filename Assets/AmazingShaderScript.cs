using UnityEngine;

[ExecuteInEditMode]
public class AmazingShaderScript : MonoBehaviour {

    public Material material;
    public bool showMaterial = true;

    void Update() {
        if (Input.GetKeyDown(KeyCode.F11)) {
            showMaterial = !showMaterial;
        }
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination) {

        if (showMaterial) {
            Graphics.Blit(source, destination, material);
        }
        else {
            Graphics.Blit(source, destination);
        }

    }
}
