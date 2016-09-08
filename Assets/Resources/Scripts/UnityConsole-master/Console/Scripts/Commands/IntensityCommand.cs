using UnityEngine;
using System;

namespace Wenzil.Console.Commands {
    public static class IntensityCommand {

        public static readonly string name = "Intensity";
        public static readonly string description = "Changes the minimal Intensity of outlines";
        public static readonly string usage = "Intensity <value[0-10]>";

        public static string Execute(params string[] args)
        {
            float minIntensity = 0;
            if (args.Length > 0 && args.Length < 2)
            {
                minIntensity = float.Parse(args[0]);
                if (minIntensity >= 0 && minIntensity <= 10)
                {
                    MaterialHandler.setMinimalIntensity(minIntensity);
                    return "The minimal Intensity is now: " + minIntensity;
                }
            }
            return usage;
        }
    }
}
