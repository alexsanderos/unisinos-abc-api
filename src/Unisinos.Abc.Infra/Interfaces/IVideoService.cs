using Unisinos.Abc.Infra.Dto.Infra;

namespace Unisinos.Abc.Infra.Interfaces
{
    public interface IVideoService
    {
        Task<VideoData> GetVideos(string courseKey);
    }
}