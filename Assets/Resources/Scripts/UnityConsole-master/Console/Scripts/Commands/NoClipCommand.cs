using UnityEngine;

namespace Wenzil.Console.Commands
{
    /// <summary>
    /// QUIT command. Quit the application.
    /// </summary>
    public static class NoClipCommand
    {
        public static readonly string name = "DAIKATANA";
        public static readonly string description = "Activate NoClip-Mode for no specific reason.";
        public static readonly string usage = "DAIKATANA";

        public static string Execute(params string[] args)
        {
            //TODO: No Clip!
            return "What a game.";
        }
    }
}