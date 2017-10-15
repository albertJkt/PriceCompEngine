using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace GoogleDirections
{
  /// <summary>
  /// Class providing methods to retrieve elevation data for locations
  /// </summary>
  public sealed class ElevationService : HttpWebService
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ElevationService" /> class.
    /// </summary>
    /// <param name="key">Your Google Maps API key.</param>
    public ElevationService(string key) : base(key)
    {
    }

    private string BaseUrl()
    {
      return string.Format("https://maps.googleapis.com/maps/api/elevation/xml?key={0}", Key);
    }

    /// <summary>
    /// Gets the elevation of the specified location.
    /// </summary>
    /// <param name="location">The location.</param>
    /// <returns>The elevation of the location</returns>
    public double GetElevation(LatLng location)
    {
      var req = string.Format("{2}&locations={0},{1}", location.Latitude.ToString(CultureInfo.InvariantCulture), location.Longitude.ToString(CultureInfo.InvariantCulture), BaseUrl());
      var resp = MakeRequest(req);
      var xmlDoc = ParseResponse(resp, GetStatusMessage);
      var val = xmlDoc.DocumentElement.SelectSingleNode("result/elevation").InnerText;
      return double.Parse(val, CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Gets the elevations for the specified locations.
    /// </summary>
    /// <param name="locations">The locations.</param>
    /// <returns>The elevations of the locations</returns>
    public IEnumerable<double> GetElevation(IEnumerable<LatLng> locations)
    {
      var req = "";
      foreach (var ll in locations)
      {
        if (req != "")
          req += "|";
        req += string.Format("{0},{1}", ll.Latitude.ToString("F6", CultureInfo.InvariantCulture), ll.Longitude.ToString("F6", CultureInfo.InvariantCulture));
      }

      var fullReq = string.Format("{0}&locations={1}", BaseUrl(), req);
      var resp = MakeRequest(fullReq);
      var xmlDoc = ParseResponse(resp, GetStatusMessage);
      var nodes = xmlDoc.DocumentElement.SelectNodes("result/elevation");
      var elevations = new List<double>();
      foreach (XmlNode node in nodes)
      {
        elevations.Add(double.Parse(node.InnerText, CultureInfo.InvariantCulture));
      }

      return elevations;
    }

    private static string GetStatusMessage(string status)
    {
      switch (status)
      {
        case "OVER_QUERY_LIMIT":
          return "Over query limit";
        default:
          throw new Exception("Unrecognised status - " + status);
      }
    }
  }
}
