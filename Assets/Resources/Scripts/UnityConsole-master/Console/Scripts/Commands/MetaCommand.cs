using UnityEngine;
using UnityStandardAssets.ImageEffects;

namespace Wenzil.Console.Commands
{
    public static class MetaCommand
    {
        public static readonly string name = "SIGHTBEYONDSIGHT";
        public static readonly string description = "Show the Metadata that is swapped between the shaders as Textures.";
        public static readonly string usage = "SIGHTBEYONDSIGHT";
        private static Camera camera = Camera.main;
        private static EdgeDetectionColor edgeScript;

        public static string Execute(params string[] args)
        {
            edgeScript = camera.GetComponent<EdgeDetectionColor>();
            edgeScript.enabled = !edgeScript.enabled;
            if (edgeScript.enabled)
            {
                return "Honestly, does anyone even get that reference?";
            }
            else
            {
                return "The Sword of Omen hears you.";
            }
        }
    }
}