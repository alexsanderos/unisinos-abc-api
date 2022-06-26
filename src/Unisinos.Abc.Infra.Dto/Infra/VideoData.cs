using System.Text.Json.Serialization;

namespace Unisinos.Abc.Infra.Dto.Infra
{
    public class VideoData
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }
        [JsonPropertyName("data")]
        public List<VideoDataItem> Data { get; set; }
    }

    public class VideoDataItem
    {
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("link")]
        public string Link { get; set; }

    }
}