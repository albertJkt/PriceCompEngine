using System;
using System.Net;
using System.IO;
using System.Xml;

namespace GoogleDirections
{
  /// <summary>
  /// Base class for using the Google Maps API
  /// </summary>
  public class HttpWebService
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="HttpWebService"/> class.
    /// </summary>
    /// <param name="key">Your Google Maps API key.</param>
    protected HttpWebService(string key)
    {
      Key = key;
    }

    /// <summary>
    /// Gets the Google Maps API key.
    /// </summary>
    public string Key { get; }

    internal static string MakeRequest(string url)
    {
      if (url.Length > 2000)
        throw new GoogleMapsException("URL length is too long");

      var req = (HttpWebRequest)WebRequest.Create(url);
      using (var resp = req.GetResponse())
      using (var respStream = resp.GetResponseStream())
      using (var reader = new StreamReader(respStream))
      {
        return reader.ReadToEnd();
      }
    }

    internal static XmlDocument ParseResponse(string response, Func<string, string> getStatusMessage)
    {
      var xmlDoc = new XmlDocument();
      xmlDoc.LoadXml(response);
      var status = xmlDoc.DocumentElement.SelectSingleNode("status").InnerText;
      if (status != "OK")
        throw new GoogleMapsException(getStatusMessage(status));

      return xmlDoc;
    }
  }
}
