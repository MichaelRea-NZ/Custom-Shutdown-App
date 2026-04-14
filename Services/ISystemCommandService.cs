using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CustomShutDown.Services
{
    // ISystemCommandService: Interface that defines the contract for system command operations
    // This follows the Dependency Inversion Principle (SOLID) - depend on abstractions, not concrete classes
    // Any class implementing this interface must provide the ability to execute system commands
    internal interface ISystemCommandService
    {
        // Method signature for executing system commands asynchronously
        // command: A SystemCommand enum value (Shutdown, Restart, or Sleep)
        // Returns: A Task representing the asynchronous operation
        // 
        // This method will:
        // 1. Take a system command (shutdown/restart/sleep)
        // 2. Execute the appropriate Windows system command
        // 3. Return asynchronously to allow the application to continue or wait
        Task ExecuteCommandAsync(SystemCommand command);
    }
}