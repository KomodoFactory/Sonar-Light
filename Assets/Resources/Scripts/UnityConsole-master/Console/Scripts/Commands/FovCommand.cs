using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Wenzil.Console.Commands {
    public static class FovCommand {

        public static readonly string name = "FOV";
        public static readonly string description = "Changes the FOV";
        public static readonly string usage = "FOV <angle>";

        public static string Execute(params string[] args) {

            Camera camera = Camera.main;
            if(args.Length != 1) {
                return usage;
            }
            try {

                int fov = Int32.Parse(args[0]);
                if(fov < 10 || fov > 170) {
                    return "please select a reasonable FOV, usually 60-100 look pretty okay";
                }
                camera.fieldOfView = fov;
            }
            catch(FormatException e) {
                return e.Message;
            }
            return "Your FOV is now " + args[0];
        }
    }
}
