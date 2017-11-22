using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace ServiceClient
{
    public class RestRequestExecutor
    {
        public async Task<string> ExecuteRestGetRequest(PCEUriBuilder builder)
        {
            var client = new RestClient(builder.ServerAddress);

            var request = new RestRequest(builder.Uri, Method.GET);

            var asyncQueryResult = await client.ExecuteTaskAsync(request);

            var result = asyncQueryResult.Content;

            return result;
        }

        public async Task<string> ExecuteRestPostRequest(PCEUriBuilder builder, byte[] image)
        {
            var client = new RestClient(builder.ServerAddress);

            var request = new RestRequest(builder.Uri, Method.POST);
            request.AddFile("image", image, "image.png");
            request.AddHeader("Content-Type", "multipart/form-data");

            var asyncQueryResult = await client.ExecuteTaskAsync(request);

            var result = asyncQueryResult.Content;

            return result;
        }

        public async void ExecuteRestPostRequest(PCEUriBuilder builder)
        {
            var client = new RestClient(builder.ServerAddress);

            var request = new RestRequest(builder.Uri, Method.POST);

            var asyncQueryResult = await client.ExecuteTaskAsync(request);
        }

        public async Task<string> ExecuteRestPostRequest(PCEUriBuilder builder, string ocrText)
        {
            var client = new RestClient(builder.ServerAddress);

            var request = new RestRequest(builder.Uri, Method.POST);

            request.AddHeader("Content-Type", "application/json");

            request.RequestFormat = DataFormat.Json;

            request.AddBody(new
            {
                Text = ocrText
            });

            var asyncQueryresult = await client.ExecuteTaskAsync(request);

            var result = asyncQueryresult.Content;

            return result;
        }
    }
}
