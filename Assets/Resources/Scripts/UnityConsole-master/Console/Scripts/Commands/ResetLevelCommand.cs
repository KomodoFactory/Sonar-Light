using UnityEngine;
using UnityEngine.SceneManagement;

namespace Wenzil.Console.Commands {
    public static class ResetLevelCommand {

        public static readonly string name = "ResetLevel";
        public static readonly string description = "Resets the Level";
        public static readonly string usage = "ResetLevel";

        public static string Execute(params string[] args) {

            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);

            return "Level " + scene.name + " Resert";
        }
    }
}
