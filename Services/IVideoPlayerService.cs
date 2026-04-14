using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomShutDown.Services
{
    // IVideoPlayerService: Interface that defines the contract for video playback operations
    // This follows the Dependency Inversion Principle (SOLID) - depend on abstractions, not concrete classes
    // Any class implementing this interface must provide the ability to play videos
    internal interface IVideoPlayerService
    {
        // Method signature for playing a video asynchronously
        // videoFilePath: The full path to the video file to play (e.g., "C:\path\to\video.mp4")
        // Returns: A Task that completes when the video finishes playing
        // 
        // This method will:
        // 1. Accept a video file path
        // 2. Play the video (creating a window, MediaElement, etc.)
        // 3. Wait asynchronously until the video finishes
        // 4. Return control to the caller when playback is complete
        Task PlayVideoAsync(string videoFilePath);
    }
}