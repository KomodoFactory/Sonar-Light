using UnityEngine;
using UnityStandardAssets.ImageEffects;

namespace Wenzil.Console.Commands
{
    /// <summary>
    /// QUIT command. Quit the application.
    /// </summary>
    public static class OutlineCommand
    {
        public static readonly string name = "STEREOBLIND";
        public static readonly string description = "Render the outlines but show rest.";
        public static readonly string usage = "STEREOBLIND";
        private static Camera camera = Camera.main;
        private static EdgeDetectionColor edgeScript;

        public static string Execute(params string[] args)
        {
            return "This shouldn't work anymore...";
        }
    }
}