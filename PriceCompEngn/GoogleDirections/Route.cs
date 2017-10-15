using System.Collections.Generic;
using System.Xml;

namespace GoogleDirections
{
  /// <summary>
  /// Class representing a route containing directions between various locations
  /// </summary>
  public sealed class Route
  {
    internal Route (XmlDocument route)
    {
      Summary = route.DocumentElement.SelectSingleNode("route/summary").InnerText;
      var legsXml = route.DocumentElement.SelectNodes("route/leg");
      _legs = new List<RouteLeg>();
      foreach (XmlElement leg in legsXml)
      {
        _legs.Add(new RouteLeg(leg));
      }
    }

    /// <summary>
    /// Gets a summary of the roads used in the calculated route.
    /// </summary>
    public string Summary { get; }

    private readonly List<RouteLeg> _legs;
    /// <summary>
    /// Gets the legs of this route.
    /// </summary>
    public IEnumerable<RouteLeg> Legs => _legs;

    /// <summary>
    /// Gets the duration of the route in seconds.
    /// </summary>
    public int Duration
    {
      get
      {
        var duration = 0;
        foreach (var leg in _legs)
        {
          duration += leg.Duration;
        }
        return duration;
      }
    }

    /// <summary>
    /// Gets the distance of the route in metres.
    /// </summary>
    public int Distance
    {
      get
      {
        var distance = 0;
        foreach (var leg in _legs)
        {
          distance += leg.Distance;
        }
        return distance;
      }
    }
  }
}
