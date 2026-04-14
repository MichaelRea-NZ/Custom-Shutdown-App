using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomShutDown.ViewModels
{
    // RelayCommand: A reusable implementation of the ICommand interface
    // This is a helper class that allows methods in the ViewModel to be executed by UI controls (like buttons)
    // Also known as DelegateCommand - it "relays" the command execution to a delegate
    public class RelayCommand : ICommand
    {
        // Stores the method to execute when the command is invoked
        private readonly Action _execute;

        // Stores the method that determines whether the command can execute
        // Optional - if null, the command can always execute
        private readonly Func<bool> _canExecute;

        // Constructor: Creates a new RelayCommand
        // execute: The method to run when the command executes (required)
        // canExecute: The method that determines if the command can run (optional)
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        // Event that fires when the CanExecute status changes
        // WPF uses this to enable/disable UI controls (like buttons)
        public event EventHandler CanExecuteChanged;

        // Determines whether the command can execute in its current state
        // parameter: Command parameter (not used in this implementation)
        // Returns: true if the command can execute, false otherwise
        public bool CanExecute(object parameter)
        {
            // If no canExecute method was provided, always return true (command can always execute)
            // Otherwise, call the canExecute method and return its result
            return _canExecute == null || _canExecute();
        }

        // Executes the command
        // parameter: Command parameter (not used in this implementation)
        public void Execute(object parameter)
        {
            // Call the execute method that was passed in the constructor
            _execute();
        }
    }
}