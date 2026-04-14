using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CustomShutDown.Services
{
    // VideoPlayerService: Concrete implementation of IVideoPlayerService
    // This class contains the actual logic for playing videos using WPF's MediaElement
    // Provides a fullscreen video playback experience before executing system commands
    internal class VideoPlayerService : IVideoPlayerService
    {
        // Plays a video file asynchronously and waits until it finishes
        // videoFilePath: The full path to the video file to play
        // Returns: A Task that completes when the video finishes playing
        public Task PlayVideoAsync(string videoFilePath)
        {
            // Create a TaskCompletionSource to manually control when the Task completes
            // This converts the event-based MediaElement into an awaitable Task
            // <bool> indicates the result type (true when video completes successfully)
            var tcs = new TaskCompletionSource<bool>();

            // Create a new WPF Window to host the video player
            var window = new Window
            {
                // Window title (visible in taskbar but not on screen due to WindowStyle.None)
                Title = "Playing Video",

                // Maximize the window to fill the entire screen
                WindowState = WindowState.Maximized,

                // Remove title bar, borders, and controls for true fullscreen experience
                WindowStyle = WindowStyle.None
            };

            // Create a MediaElement control to play the video
            var mediaElement = new MediaElement
            {
                // Set the video file to play using a URI
                Source = new Uri(videoFilePath),

                // Manual mode means we control playback programmatically (not automatic)
                LoadedBehavior = MediaState.Manual
            };

            // Subscribe to the MediaEnded event - fires when video playback completes
            // (s, e) is a lambda expression: s = sender, e = event args
            mediaElement.MediaEnded += (s, e) =>
            {
                // Close the video window when playback finishes
                window.Close();

                // Signal that the Task is complete by setting result to true
                // This allows the awaiting code to continue execution
                tcs.SetResult(true);
            };

            // Set the MediaElement as the content of the window
            window.Content = mediaElement;

            // Display the window on screen
            window.Show();

            // Start playing the video
            mediaElement.Play();

            // Return the Task that will complete when the MediaEnded event fires
            // The caller can await this Task to wait for the video to finish
            return tcs.Task;
        }
    }
}