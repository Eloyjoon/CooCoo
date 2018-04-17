﻿using Command.Abstracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Command
{
    public class CommandProcessor : ICommandProcessor
    {
        private IModuleLoader _ModuleLoader;
        public IModuleLoader ModuleLoader => _ModuleLoader;
        public CommandProcessor(IModuleLoader moduleLoader)
        {
            _ModuleLoader = moduleLoader;
        }
        public void ProcessCommands(string key)
        {
            if (Brain.State == State.Disabled && (key.ToLower() != "start coocoo" && key.ToLower() != "state coocoo")) return;

            foreach (var command in ModuleLoader.CommandsList)
            {
                if (!command.Equals(key)) continue;
                command.DoJob();
                Brain.PreviousCommand = command;
                return;

            }
        }
    }
}