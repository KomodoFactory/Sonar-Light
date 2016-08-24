using UnityEngine;

namespace Wenzil.Console.Commands
{
    /// <summary>
    /// QUIT command. Quit the application.
    /// </summary>
    public static class OutlineCommand
    {
        public static readonly string name = "blib";
        public static readonly string description = "Return a Blib.";
        public static readonly string usage = "blibeling";

        public static string Execute(params string[] args)
        {
            return "blib...";
        }
    }
}