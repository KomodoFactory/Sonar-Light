using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects {
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    [AddComponentMenu("Image Effects/Edge Detection/Edge Detection Color")]
    public class EdgeDetectionColor : PostEffectsBase {

        
        public float sensitivityDepth = 0.5f;
        public float sensitivityNormals = 7.0f;
        public Color backgroundColor = Color.black;
        public Color edgesColor = Color.blue;

        private Shader edgeDetectShader;
        private Material edgeDetectMaterial = null;


        private float sampleDist = 0.5f;
        private int mode = 0;


        public override bool CheckResources() {
            CheckSupport(true);

            if (edgeDetectShader == null) {
                edgeDetectShader = (Shader)Resources.Load("Scripts/Shader/EdgeDetectNormalsColor");
            }
            edgeDetectMaterial = CheckShaderAndCreateMaterial(edgeDetectShader, edgeDetectMaterial);
            if (!isSupported)
                ReportAutoDisable();
            return isSupported;
        }


        void SetCameraFlag() {
            GetComponent<Camera>().depthTextureMode |= DepthTextureMode.DepthNormals;
            GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
        }

        void OnEnable() {
            SetCameraFlag();
        }

        [ImageEffectOpaque]
        void OnRenderImage(RenderTexture source, RenderTexture destination) {
            if (CheckResources() == false) {
                Graphics.Blit(source, destination);
                return;
            }
            if (edgeDetectMaterial == null) {
                edgeDetectShader = Shader.Find("Hidden/EdgeDetectColors");
                edgeDetectMaterial = CheckShaderAndCreateMaterial(edgeDetectShader, edgeDetectMaterial);
            }
            Vector2 sensitivity = new Vector2(sensitivityDepth, sensitivityNormals);
            //Camerarparameter
            edgeDetectMaterial.SetVector("_CameraForward", Camera.main.transform.forward);
            edgeDetectMaterial.SetFloat("_ClipingDistance", Camera.main.farClipPlane);
            //Edgedetectionparameers
            edgeDetectMaterial.SetVector("_Sensitivity", new Vector4(sensitivity.x, sensitivity.y, 1.0f, sensitivity.y));
            edgeDetectMaterial.SetFloat("_SampleDistance", sampleDist);
            //Colorparameter
            edgeDetectMaterial.SetFloat("_BgFade", 1);
            edgeDetectMaterial.SetVector("_EdgeColor", edgesColor);
            edgeDetectMaterial.SetVector("_BackgroundColor", backgroundColor);

            Graphics.Blit(source, destination, edgeDetectMaterial, mode);
        }
    }
}
