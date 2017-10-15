using System.Collections.Generic;
using System.Xml;

namespace GoogleDirections
{
  /// <summary>
  /// Class representing the leg of a route
  /// </summary>
  public sealed class RouteLeg
  {
    internal RouteLeg(XmlElement leg)
    {
      StartAddress = leg.SelectSingleNode("start_address").InnerText;
      EndAddress = leg.SelectSingleNode("end_address").InnerText;
      Distance = int.Parse(leg.SelectSingleNode("distance/value").InnerText);
      Duration = int.Parse(leg.SelectSingleNode("duration/value").InnerText);
      StartLocation = new LatLng((XmlElement)leg.SelectSingleNode("start_location"));
      EndLocation = new LatLng((XmlElement)leg.SelectSingleNode("end_location"));

      var stepsXml = leg.SelectNodes("step");
      var stepsList = new List<RouteStep>();
      foreach (XmlElement step in stepsXml)
      {
        stepsList.Add(new RouteStep(step));
      }
      Steps = stepsList;
    }

    /// <summary>
    /// Gets the start address for this leg.
    /// </summary>
    public string StartAddress { get; }

    /// <summary>
    /// Gets the end address for this leg.
    /// </summary>
    public string EndAddress { get; }

    /// <summary>
    /// Gets the duration of this leg in seconds.
    /// </summary>
    public int Duration { get; }

    /// <summary>
    /// Gets the distance of this leg in metres.
    /// </summary>
    public int Distance { get; }

    /// <summary>
    /// Gets the steps for this leg of the route.
    /// </summary>
    public IEnumerable<RouteStep> Steps { get; }

    /// <summary>
    /// Gets the start location of this leg of the route.
    /// </summary>
    public LatLng StartLocation { get; }

    /// <summary>
    /// Gets the end location of this leg of the route.
    /// </summary>
    public LatLng EndLocation { get; }
  }
}
