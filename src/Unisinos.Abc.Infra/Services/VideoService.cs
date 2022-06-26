using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.Extensions.Configuration;
using Unisinos.Abc.Infra.Dto.Infra;
using Unisinos.Abc.Infra.Interfaces;

namespace Unisinos.Abc.Infra.Services
{
    public class VideoService : IVideoService
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly IConfiguration _configuration;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _baseUrl;
        private readonly string _userId = "";


        public VideoService()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            _clientId = _configuration.GetSection("VimeoService:ClientId").Value;
            _clientSecret = _configuration.GetSection("VimeoService:ClientSecret").Value;
            _baseUrl = _configuration.GetSection("VimeoService:BaseUrl").Value;
            _userId = _configuration.GetSection("VimeoService:UserId").Value;
        }


        private async Task<string> GetToken()
        {
            var grantType = "client_credentials";
            string url = "oauth/authorize/client";
            var access_token = "";

            var json = JsonSerializer.Serialize(new
            {
                grant_type = grantType,
                scope = "public"
            });

            var request = new HttpRequestMessage(HttpMethod.Post, _baseUrl + url)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("basic", Convert.ToBase64String(
                    Encoding.ASCII.GetBytes(
                        string.Format("{0}:{1}", _clientId, _clientSecret))
                ));

            string responseText = await _client.SendAsync(request).Result.Content.ReadAsStringAsync();

            ResponseToken response = JsonSerializer.Deserialize<ResponseToken>(responseText);

            if (response != null)
            {
                access_token = response.access_token;
            }

            return access_token;
        }

        public async Task<VideoData> GetVideos(string courseKeys)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["query"] = courseKeys;
            query["query_fields"] = "title";
            string queryString = query.ToString();

            var request = new HttpRequestMessage(HttpMethod.Get, _baseUrl + $"users/{_userId}/videos?{queryString}");


            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await GetToken());

            string responseText = await _client.SendAsync(request).Result.Content.ReadAsStringAsync();

            VideoData result = JsonSerializer.Deserialize<VideoData>(responseText);

            return result;
        }

        internal class ResponseToken
        {
            public string access_token { get; set; }
        }
    }
}