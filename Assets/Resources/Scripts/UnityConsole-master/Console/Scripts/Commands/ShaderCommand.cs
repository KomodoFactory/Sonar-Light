using UnityEngine;
using UnityStandardAssets.ImageEffects;

namespace Wenzil.Console.Commands
{

    public static class ShaderCommand
    {
        public static readonly string name = "NONBLIND";
        public static readonly string description = "Render the scene normaly";
        public static readonly string usage = "NONBLIND";
        private static Camera camera = Camera.main;
        private static EdgeDetectionColor edgeScript;



        public static string Execute(params string[] args)
        {
            GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
            foreach (GameObject go in allObjects)
            {
                if (go.GetComponent<Renderer>() != null)
                {
                    Debug.Log(go.GetComponent<Renderer>().material);
                }
            }



            /*edgeScript = camera.GetComponent<EdgeDetectionColor>();
            edgeScript.enabled = !edgeScript.enabled;*/
            return "You're not blind, I see.";
        }
    }
}