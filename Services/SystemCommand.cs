using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomShutDown.Services
{
    // SystemCommand: Enumeration that defines the available system power commands
    // An enum is a special type that represents a fixed set of named constants
    // This follows the DRY (Don't Repeat Yourself) principle and type safety
    internal enum SystemCommand
    {
        // Represents a command to shut down the computer
        // Value: 0 (default first enum value)
        Shutdown,

        // Represents a command to restart the computer
        // Value: 1
        Restart,

        // Represents a command to put the computer to sleep
        // Value: 2
        Sleep
    }
}