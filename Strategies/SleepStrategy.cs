using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomShutDown.Services;

namespace CustomShutDown.Strategies
{
    internal class SleepStrategy : IShutdownStrategy
    {
        private readonly IVideoPlayerService _videoPlayerService;
        private readonly ISystemCommandService _systemCommandService;
        private readonly string _videoFilePath;

        public SleepStrategy(IVideoPlayerService videoPlayerService, ISystemCommandService systemCommandService, string videoFilePath)
        {
            _videoPlayerService = videoPlayerService;
            _systemCommandService = systemCommandService;
            _videoFilePath = videoFilePath;
        }

        public async Task ExecuteAsync()
        {
            await _videoPlayerService.PlayVideoAsync(_videoFilePath);
            await _systemCommandService.ExecuteCommandAsync(SystemCommand.Sleep);
        }
    }
}
