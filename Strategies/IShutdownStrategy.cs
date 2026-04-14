using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomShutDown.Strategies
{
    // IShutdownStrategy: Interface that defines the contract for all shutdown strategies
    // This is the core of the Strategy Pattern - it defines what all strategies must do
    // Each concrete strategy (ShutdownStrategy, RestartStrategy, SleepStrategy) implements this interface
    // This follows the Strategy Pattern and the Interface Segregation Principle (SOLID)
    internal interface IShutdownStrategy
    {
        // Method signature for executing a shutdown strategy asynchronously
        // Each strategy implements this differently:
        // - ShutdownStrategy: plays video, then shuts down the computer
        // - RestartStrategy: plays video, then restarts the computer
        // - SleepStrategy: plays video, then puts the computer to sleep
        // 
        // Returns: A Task representing the asynchronous operation
        // The Task completes after the video plays and the system command executes
        Task ExecuteAsync();
    }
}