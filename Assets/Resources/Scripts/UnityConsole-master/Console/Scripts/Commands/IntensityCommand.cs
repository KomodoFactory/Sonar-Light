using UnityEngine;
using System;

namespace Wenzil.Console.Commands {
    public static class IntensityCommand {

        public static readonly string name = "Intensity";
        public static readonly string description = "Changes the Intensity multiplier of outlines";
        public static readonly string usage = "Intensity <value[1-50]>";

        public static string Execute(params string[] args)
        {
            float minIntensity = 1;
            if (args.Length > 0 && args.Length < 2)
            {
                minIntensity = float.Parse(args[0]);
                if (minIntensity >= 1 && minIntensity <= 50)
                {
                    MaterialHandler.setMinimalIntensity(minIntensity);
                    return "The Intensity multiplier is now: " + minIntensity;
                }
            }
            return usage;
        }
    }
}
