using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects {
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    public class PlayingWithShaders : PostEffectsBase {


        private Shader shader;
        private Material material;

        [ImageEffectOpaque]
        void OnRenderImage(RenderTexture source, RenderTexture destination) {


            //Debug.Log(GameObject.FindGameObjectsWithTag("Player")[0].transform.position);

            if (material == null) {

                Camera.main.depthTextureMode = DepthTextureMode.DepthNormals;


                shader = Shader.Find("Custom/PlayingWithShaders");

                material = CheckShaderAndCreateMaterial(shader, material);
            }


            Graphics.Blit(source, destination, material);
        }

        public override bool CheckResources() {
            return true;
        }
        
    }
}