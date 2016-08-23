using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects {
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    [AddComponentMenu("Image Effects/Edge Detection/Edge Detection Color")]
    public class EdgeDetectionColor : PostEffectsBase {



        float distance = 1;


        public int mode = 0;
        public float sensitivityDepth = 0.5f;
        public float sensitivityNormals = 7.0f;
        public float lumThreshold = 0.2f;
        public float edgeExp = 1.0f;
        public float sampleDist = 0.5f;
        public Color edgesOnlyBgColor = Color.black;
        public Color edgesColor = Color.blue;

        public Shader edgeDetectShader;
        public Material edgeDetectMaterial = null;


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
            edgeDetectMaterial.SetVector("_Sensitivity", new Vector4(sensitivity.x, sensitivity.y, 1.0f, sensitivity.y));
            edgeDetectMaterial.SetFloat("_BgFade", 1);
            edgeDetectMaterial.SetFloat("_SampleDistance", sampleDist);
            edgeDetectMaterial.SetVector("_BgColor", edgesOnlyBgColor);
            edgeDetectMaterial.SetFloat("_Exponent", edgeExp);
            edgeDetectMaterial.SetFloat("_Threshold", lumThreshold);
            edgeDetectMaterial.SetVector("_EdgeColor", edgesColor);

           //Vector3 pos = Camera.main.transform.position;
            edgeDetectMaterial.SetFloat("_Distance", 10.0f);
            //edgeDetectMaterial.SetVector("_Position", new Vector4(pos.x, pos.y, pos.z, 1.0f));
            edgeDetectMaterial.SetVector("_CameraForward",Camera.main.transform.forward * Camera.main.farClipPlane);
            edgeDetectMaterial.SetFloat("_ClipingDistance", Camera.main.farClipPlane);


            edgeDetectMaterial.SetFloat("_TempOnlyDistance",distance);
            distance += 0.1f;
            if (distance >= 20){
                distance = 0;
            }


            Graphics.Blit(source, destination, edgeDetectMaterial, mode);
        }
    }
}
