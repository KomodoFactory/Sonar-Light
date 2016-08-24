using UnityEngine;

namespace Wenzil.Console.Commands
{
    /// <summary>
    /// QUIT command. Quit the application.
    /// </summary>
    public static class ShaderCommand
    {
        public static readonly string name = "NONBLIND";
        public static readonly string description = "Render the scene normaly";
        public static readonly string usage = "NONBLIND";

        public static string Execute(params string[] args)
        {
            return "You're not blind I see.";
        }
    }
}