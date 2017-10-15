using System;

namespace GoogleDirections
{
  /// <summary>
  /// Class providing methods to retrieve directions between locations
  /// </summary>
  public sealed class RouteDirections : HttpWebService
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="RouteDirections"/> class.
    /// </summary>
    /// <param name="key">Your Google Maps API key.</param>
    public RouteDirections(string key) : base(key)
    {
      
    }

    /// <summary>
    /// Gets a route from the Google Maps Directions web service.
    /// </summary>
    /// <param name="optimize">if set to <c>true</c> optimize the route by re-ordering the locations to minimise the
    /// time to complete the route.</param>
    /// <param name="locations">The locations.</param>
    /// <returns>The route</returns>
    public Route GetRoute(bool optimize, params Location[] locations)
    {
      if (locations.Length < 2)
        throw new ArgumentException("locations parameter must contains 2 or more locations", nameof(locations));

      var reqStr = "origin=" + locations[0] + "&destination=" + locations[locations.Length-1];

      if (locations.Length > 2)
      {
        reqStr += "&waypoints=optimize:" + optimize.ToString().ToLower();
        for (var i = 1; i < locations.Length - 1; i++)
        {
          reqStr += "|";
          reqStr += locations[i].ToString();
        }
      }

      return ParseResponse(MakeRequest(
        "http://maps.googleapis.com/maps/api/directions/xml?sensor=false&" + reqStr));
    }

    private static Route ParseResponse(string response)
    {
      var xmlDoc = ParseResponse(response, GetStatusMessage);
      return new Route(xmlDoc);
    }

    private static string GetStatusMessage(string status)
    {
      switch (status)
      {
        case "ZERO_RESULTS" : return "No route found";
        case "NOT_FOUND": return "Not found";
        // TODO - other status messages
        default:
          throw new Exception("Unrecognised status - " + status);
      }
    }
  }
}
