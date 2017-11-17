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
        public async Task<string> ExecuteRestGetRequest(URIBuilder builder)
        {
            var client = new RestClient(builder.ServerAddress);

            var request = new RestRequest(builder.Uri, Method.GET);

            var asyncQueryResult = await client.ExecuteTaskAsync(request);

            var result = asyncQueryResult.Content;

            return result;
        }

        public async Task<string> ExecuteRestPostRequest(URIBuilder builder, byte[] image)
        {
            var client = new RestClient(builder.ServerAddress);

            var request = new RestRequest(builder.Uri, Method.POST);
            request.AddFile("image", image, "image.png");
            request.AddHeader("Content-Type", "multipart/form-data");

            var asyncQueryResult = await client.ExecuteTaskAsync(request);

            var result = asyncQueryResult.Content;

            return result;
        }
    }
}
