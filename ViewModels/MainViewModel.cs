using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;
using CustomShutDown.Services;
using CustomShutDown.Strategies;

namespace CustomShutDown.ViewModels
{
    // MainViewModel: The ViewModel in the MVVM pattern
    // Manages UI state and business logic for the main window
    // Implements INotifyPropertyChanged to notify the UI when properties change
    internal class MainViewModel : INotifyPropertyChanged
    {
        // Commands exposed to the UI for button binding
        // These are bound to the Sleep, Restart, and Shutdown buttons in MainWindow.xaml
        public ICommand ShutdownCommand { get; }
        public ICommand RestartCommand { get; }
        public ICommand SleepCommand { get; }

        // Constructor: Initializes the ViewModel
        public MainViewModel()
        {
            // Set the video file path to the ShutdownVideo.mp4 file in the application's directory
            VideoFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ShutdownVideo.mp4");

            // Initialize commands with their corresponding execution methods
            // RelayCommand is a helper class that implements ICommand
            ShutdownCommand = new RelayCommand(ExecuteShutdown);
            RestartCommand = new RelayCommand(ExecuteRestart);
            SleepCommand = new RelayCommand(ExecuteSleep);
        }

        // INotifyPropertyChanged implementation
        // This event notifies the UI when a property value changes
        public event PropertyChangedEventHandler? PropertyChanged;

        // Helper method to raise the PropertyChanged event
        // Called whenever a property value changes to update the UI
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Backing field for VideoFilePath property
        private string _videoFilePath;

        // Property that stores the path to the video file
        // Uses INotifyPropertyChanged pattern to notify UI of changes
        public string VideoFilePath
        {
            get => _videoFilePath;
            set
            {
                _videoFilePath = value;
                // Notify UI that this property changed
                OnPropertyChanged(nameof(VideoFilePath));
                // Tell WPF to re-evaluate CanExecute on all commands
                CommandManager.InvalidateRequerySuggested();
            }
        }

        // Execute method for the Shutdown command
        // Called when user clicks the Shutdown button
        private async void ExecuteShutdown()
        {
            // Create instances of the required services
            var videoService = new VideoPlayerService();
            var systemService = new SystemCommandService();

            // Create a ShutdownStrategy with the services and video path
            // This is the Strategy Pattern - selecting the shutdown strategy at runtime
            var strategy = new ShutdownStrategy(videoService, systemService, VideoFilePath);

            // Execute the strategy asynchronously (plays video, then shuts down)
            await strategy.ExecuteAsync();
        }

        // Execute method for the Restart command
        // Called when user clicks the Restart button
        private async void ExecuteRestart()
        {
            // Create service instances
            var videoService = new VideoPlayerService();
            var systemService = new SystemCommandService();

            // Create RestartStrategy - same pattern as shutdown but different action
            var strategy = new RestartStrategy(videoService, systemService, VideoFilePath);

            // Execute the strategy (plays video, then restarts)
            await strategy.ExecuteAsync();
        }

        // Execute method for the Sleep command
        // Called when user clicks the Sleep button
        private async void ExecuteSleep()
        {
            // Create service instances
            var videoService = new VideoPlayerService();
            var systemService = new SystemCommandService();

            // Create SleepStrategy - same pattern but puts computer to sleep
            var strategy = new SleepStrategy(videoService, systemService, VideoFilePath);

            // Execute the strategy (plays video, then sleeps)
            await strategy.ExecuteAsync();
        }
    }
}