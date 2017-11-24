using DataBase;
using OCREngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logic;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Web.Hosting;
using System.Threading.Tasks;
using System.Web;
using PriceCompEngineAPI.Extensions;

namespace PriceCompEngineAPI.Controllers
{
    public class OCRController : ApiController
    {
        [HttpPost]
        public async Task<string> Post(HttpRequestMessage request)
        {
            if (!request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var data = await request.Content.ParseMultipartAsync();

            if (data.Files.ContainsKey("image"))
            {
                var file = data.Files["image"].File;
                string imageText = OCREngineAPI.GetImageText(file, "lt", ResultFormat.TEXT);

                return imageText;
            }
            else return null;
        }       
    }
}
