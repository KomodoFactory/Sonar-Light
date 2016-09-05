using UnityEngine;

namespace Wenzil.Console.Commands
{

    public static class ShaderCommand
    {
        public static readonly string name = "NONBLIND";
        public static readonly string description = "Render the scene normaly";
        public static readonly string usage = "NONBLIND";
        private static Renderer renderer;
        private static MaterialHandler matHandler = MaterialHandler.getInstance();
        private static bool shaderOnOff;

        public static string Execute(params string[] args)
        {
            GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
            foreach (GameObject go in allObjects)
            {
                renderer = go.GetComponent<Renderer>();
                if (renderer != null)
                {
                    if (renderer.sharedMaterial != null)
                    {
                        shaderOnOff = matHandler.switchMaterial(renderer);
                    }
                }
            }

            if (shaderOnOff)
            {
                return "You're blind then.";
            }
            return "You're not blind, I see.";
        }
    }
}