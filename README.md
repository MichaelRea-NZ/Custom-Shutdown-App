Custom Shutdown - WPF Application

A Windows desktop application that plays a video before executing system power commands (shutdown, restart, or sleep). Built with C# and WPF, demonstrating the Strategy Pattern and MVVM architecture.

This application allows users to:
Select a power action (Sleep, Restart, or Shutdown).
Watch a custom video in fullscreen.
Automatically execute the selected system command after the video completes.

Architecture & Design Patterns
This project demonstrates professional software engineering principles:

Strategy Pattern
IShutdownStrategy interface with three concrete implementations.
Runtime strategy selection based on user choice.
Clean separation of algorithm variants.
Allows for future strategies to be added, eg. Update and Restart.

MVVM Architecture
Model: Services and Strategies (business logic).
View: MainWindow.xaml (UI).
ViewModel: MainViewModel (presentation logic).

Potential improvements:
 Add confirmation dialog before executing commands.
 Configuration file for video path and settings.
 Error handling for missing video file.
 Skip video option.
 Progress bar during video playback.
 Support for multiple videos (random selection).
 Hibernate option.
 Countdown timer.
 Logging functionality.

CustomShutDown/
├── Strategies/
│   ├── IShutdownStrategy.cs          # Strategy pattern interface
│   ├── ShutdownStrategy.cs           # Shutdown implementation
│   ├── RestartStrategy.cs            # Restart implementation
│   └── SleepStrategy.cs              # Sleep implementation
├── Services/
│   ├── IVideoPlayerService.cs        # Video playback interface
│   ├── VideoPlayerService.cs         # WPF MediaElement implementation
│   ├── ISystemCommandService.cs      # System command interface
│   ├── SystemCommandService.cs       # Windows command implementation
│   └── SystemCommand.cs              # Enum: Shutdown, Restart, Sleep
├── ViewModels/
│   ├── MainViewModel.cs              # MVVM ViewModel
│   └── RelayCommand.cs               # ICommand helper
├── Views/
│   └── MainWindow.xaml               # Main UI
└── ShutdownVideo.mp4                 # Your custom video file
