using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomShutDown.Services
{
    // SystemCommandService: Concrete implementation of ISystemCommandService
    // This class contains the actual logic for executing Windows system commands
    // Implements the service interface to provide system power management functionality
    internal class SystemCommandService : ISystemCommandService
    {
        // Executes a system command (shutdown, restart, or sleep) asynchronously
        // command: The SystemCommand enum value specifying which action to perform
        // Returns: A completed Task once the command is executed
        public async Task ExecuteCommandAsync(SystemCommand command)
        {
            // Use a switch expression to map the enum to the actual Windows command string
            // This converts our high-level command into the low-level OS command
            string commandText = command switch
            {
                // Shutdown command: /s = shutdown, /t 0 = timeout of 0 seconds (immediate)
                SystemCommand.Shutdown => "shutdown /s /t 0",

                // Restart command: /r = restart, /t 0 = timeout of 0 seconds (immediate)
                SystemCommand.Restart => "shutdown /r /t 0",

                // Sleep command: Uses Windows power profile DLL to suspend the system
                // Parameters: 0,1,0 = Standby (not hibernate), force suspend, disable wake events
                SystemCommand.Sleep => "rundll32.exe powrprof.dll,SetSuspendState 0,1,0",

                // Default case: if an invalid command is passed, throw an exception
                // The underscore (_) is a discard pattern that matches anything
                _ => throw new ArgumentException("Invalid command")
            };

            // Execute the command using the Windows command prompt
            // /c tells cmd.exe to execute the command and then terminate
            // Process.Start creates a new process to run the command
            Process.Start("cmd.exe", $"/c {commandText}");

            // Return a completed task to satisfy the async method signature
            // Since Process.Start is synchronous, we use Task.CompletedTask
            await Task.CompletedTask;
        }
    }
}