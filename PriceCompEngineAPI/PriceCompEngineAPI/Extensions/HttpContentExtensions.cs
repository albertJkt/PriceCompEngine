using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PriceCompEngineAPI.Extensions
{
    public static class HttpContentExtensions
    {
        public static async Task<HttpPostedData> ParseMultipartAsync(this HttpContent postedContent)
        {
            var provider = await postedContent.ReadAsMultipartAsync();

            var files = new Dictionary<string, HttpPostedFile>(StringComparer.InvariantCultureIgnoreCase);
            var fields = new Dictionary<string, HttpPostedField>(StringComparer.InvariantCultureIgnoreCase);

            foreach (var content in provider.Contents)
            {
                var fieldName = content.Headers.ContentDisposition.Name.Trim('"');
                if (!string.IsNullOrEmpty(content.Headers.ContentDisposition.FileName))
                {
                    var file = await content.ReadAsByteArrayAsync();
                    var fileName = content.Headers.ContentDisposition.FileName.Trim('"');
                    files.Add(fieldName, new HttpPostedFile(fieldName, fileName, file));
                }
                else
                {
                    var data = await content.ReadAsStringAsync();
                    fields.Add(fieldName, new HttpPostedField(fieldName, data));
                }
            }

            return new HttpPostedData(fields, files);
        }
    }

    public class HttpPostedField
    {
        public string Name { private set; get; }
        public string Value { private set; get; }

        public HttpPostedField(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }

    public class HttpPostedFile
    {
        public string Name { get; private set; }
        public string FileName { get; private set; }
        public byte[] File { get; private set; }

        public HttpPostedFile(string name, string filename, byte[] file)
        {
            Name = name;
            FileName = filename;
            File = file;
        }
    }

    public class HttpPostedData
    {
        public IDictionary<string, HttpPostedField> Fields { get; private set; }
        public IDictionary<string, HttpPostedFile> Files { get; private set; }

        public HttpPostedData(IDictionary<string, HttpPostedField> fields, IDictionary<string, HttpPostedFile> files)
        {
            Fields = fields;
            Files = files;
        }
    }
}