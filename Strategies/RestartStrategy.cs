using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomShutDown.Services;

namespace CustomShutDown.Strategies
{
    // RestartStrategy: Concrete implementation of IShutdownStrategy for restarting the computer
    // This is one of three strategies in the Strategy Pattern (Shutdown, Restart, Sleep)
    // Encapsulates the specific behavior: play video, then restart the computer
    internal class RestartStrategy : IShutdownStrategy
    {
        // Private fields to store dependencies (services and video path)
        // These are injected through the constructor (Dependency Injection)
        // 'readonly' means they can only be set in the constructor and cannot be changed later

        // Service for playing videos - depends on interface, not concrete implementation
        private readonly IVideoPlayerService _videoPlayerService;

        // Service for executing system commands - depends on interface, not concrete implementation
        private readonly ISystemCommandService _systemCommandService;

        // Path to the video file that will be played before restarting
        private readonly string _videoFilePath;

        // Constructor: Receives dependencies through Dependency Injection
        // This follows the Dependency Inversion Principle (SOLID) - depend on abstractions, not concretions
        // videoPlayerService: Service to handle video playback
        // systemCommandService: Service to execute system commands
        // videoFilePath: Full path to the video file to play
        public RestartStrategy(IVideoPlayerService videoPlayerService, ISystemCommandService systemCommandService, string videoFilePath)
        {
            // Store the injected dependencies in private fields for later use
            _videoPlayerService = videoPlayerService;
            _systemCommandService = systemCommandService;
            _videoFilePath = videoFilePath;
        }

        // ExecuteAsync: Implements the strategy's behavior (required by IShutdownStrategy interface)
        // This is where the actual restart logic happens
        // Returns: A Task that completes when both video playback and restart command finish
        public async Task ExecuteAsync()
        {
            // Step 1: Play the video and wait for it to complete
            // 'await' pauses execution here until the video finishes playing
            await _videoPlayerService.PlayVideoAsync(_videoFilePath);

            // Step 2: After video completes, execute the restart command
            // 'await' ensures the restart command is sent before the method completes
            await _systemCommandService.ExecuteCommandAsync(SystemCommand.Restart);
        }
    }
}