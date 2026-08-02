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
Allows for future strategies to be added, e.g. Update and Restart.

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

<img width="599" height="346" alt="image" src="https://github.com/user-attachments/assets/fab83e91-add1-44b7-b9b3-59123f2ffe0d" />

