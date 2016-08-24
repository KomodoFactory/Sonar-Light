using UnityEngine;

namespace Wenzil.Console.Commands
{
    /// <summary>
    /// QUIT command. Quit the application.
    /// </summary>
    public static class MetaCommand
    {
        public static readonly string name = "SIGHTBEYONDSIGHT";
        public static readonly string description = "See what can not be seen with human eyes.";
        public static readonly string usage = "SIGHTBEYONDSIGHT";

        public static string Execute(params string[] args)
        {
            return "Thundercats much?";
        }
    }
}