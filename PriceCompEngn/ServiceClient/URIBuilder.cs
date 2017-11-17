using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ServiceClient
{
    [Flags]
    public enum Resources
    {
        TextManager,
        CheapestItems,
        TopItems,
        ShoppingCart,
        PriceComparator
    };

    public class URIBuilder
    {
        private StringBuilder _uri;
        public string Uri
        {
            get
            {
                if (_uri != null)
                    return _uri.ToString();
                else return null;
            }
        }
        public string ServerAddress { get; private set; }

        public URIBuilder(Resources resource)
        {
            string resourcePath = ConfigurationManager.AppSettings[resource.ToString() + "Url"];
            _uri = new StringBuilder(resourcePath);

            string serverPath = ConfigurationManager.AppSettings.Get("ServiceBaseUrl");
            ServerAddress = serverPath;
        }

        public void AppendStringArgs(Dictionary<string, string> args)
        {
            if (args != null)
            {
                foreach(KeyValuePair<string, string> entry in args)
                {
                    _uri.Append(entry.Key);
                    _uri.Append('=');
                    _uri.Append(entry.Value);
                    _uri.Append('&');
                }
            }
        }

        public void AppendNumericArgs(Dictionary<string, int> args)
        {
            if (args != null)
            {
                foreach(KeyValuePair<string, int> entry in args)
                {
                    _uri.Append(entry.Key);
                    _uri.Append('=');
                    _uri.Append(entry.Value);
                    _uri.Append('&');
                }
            }
        }

        public void AppendArrayArgs(string arrayName, Array array)
        {
            if (array.Length > 0)
            {
                foreach (Object item in array)
                {
                    _uri.Append(arrayName);
                    _uri.Append('=');
                    _uri.Append(item.ToString());
                    _uri.Append('&');
                }
            }            
        }

        public override string ToString()
        {
            return _uri.ToString();
        }
    }
}
