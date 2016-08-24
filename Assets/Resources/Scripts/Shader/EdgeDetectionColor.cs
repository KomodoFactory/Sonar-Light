using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects {
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    [AddComponentMenu("Image Effects/Edge Detection/Edge Detection Color")]
    public class EdgeDetectionColor : PostEffectsBase {



        float distance = 0;


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


        public GameObject firstHeldObject;


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

            edgeDetectMaterial.SetFloat("_TempOnlyDistance", 20);
            edgeDetectMaterial.SetMatrix("_InverseProjection", Camera.main.projectionMatrix.inverse);

            PickupObjects pickupScript = (PickupObjects)GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PickupObjects>();
            if (pickupScript.getHeldObject() != null) {
                firstHeldObject = pickupScript.getHeldObject();
            }

            if (firstHeldObject != null) {
                edgeDetectMaterial.SetVector("_ReferencePoint", firstHeldObject.transform.position);
            }

            distance += 0.1f;
            if (distance >= 20) {
                distance = 0;
            }


            Graphics.Blit(source, destination, edgeDetectMaterial, mode);
        }
    }
}
