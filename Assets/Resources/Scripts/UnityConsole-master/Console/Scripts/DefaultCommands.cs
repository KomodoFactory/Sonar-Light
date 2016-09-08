using UnityEngine;
using Wenzil.Console.Commands;

namespace Wenzil.Console {
    public class DefaultCommands : MonoBehaviour {
        void Start() {
            ConsoleCommandsDatabase.RegisterCommand(QuitCommand.name, QuitCommand.description, QuitCommand.usage, QuitCommand.Execute);
            ConsoleCommandsDatabase.RegisterCommand(HelpCommand.name, HelpCommand.description, HelpCommand.usage, HelpCommand.Execute);
            ConsoleCommandsDatabase.RegisterCommand(LoadCommand.name, LoadCommand.description, LoadCommand.usage, LoadCommand.Execute);
            ConsoleCommandsDatabase.RegisterCommand(MetaCommand.name, MetaCommand.description, MetaCommand.usage, MetaCommand.Execute);
            ConsoleCommandsDatabase.RegisterCommand(OutlineCommand.name, OutlineCommand.description, OutlineCommand.usage, OutlineCommand.Execute);
            ConsoleCommandsDatabase.RegisterCommand(ShaderCommand.name, ShaderCommand.description, ShaderCommand.usage, ShaderCommand.Execute);
            ConsoleCommandsDatabase.RegisterCommand(ResetLevelCommand.name, ResetLevelCommand.description, ResetLevelCommand.usage, ResetLevelCommand.Execute);
            ConsoleCommandsDatabase.RegisterCommand(SpawnObjectCommand.name, SpawnObjectCommand.description, SpawnObjectCommand.usage, SpawnObjectCommand.Execute);
            ConsoleCommandsDatabase.RegisterCommand(FovCommand.name, FovCommand.description, FovCommand.usage, FovCommand.Execute);
            ConsoleCommandsDatabase.RegisterCommand(IntensityCommand.name, IntensityCommand.description, IntensityCommand.usage, IntensityCommand.Execute);
        }
    }
}
