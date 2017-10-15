using System.Xml;

namespace GoogleDirections
{
  /// <summary>
  /// Class representing a step within a leg of a route
  /// </summary>
  public sealed class RouteStep
  {
    internal RouteStep(XmlElement step)
    {
      Distance = int.Parse(step.SelectSingleNode("distance/value").InnerText);
      Duration = int.Parse(step.SelectSingleNode("duration/value").InnerText);
      StartLocation = new LatLng((XmlElement)step.SelectSingleNode("start_location"));
      EndLocation = new LatLng((XmlElement)step.SelectSingleNode("end_location"));
      HtmlInstructions = step.SelectSingleNode("html_instructions").InnerText;
    }

    /// <summary>
    /// Gets the duration of this step in seconds.
    /// </summary>
    public int Duration { get; }

    /// <summary>
    /// Gets the distance in metres for this step.
    /// </summary>
    public int Distance { get; }

    /// <summary>
    /// Gets the start location for this step.
    /// </summary>
    public LatLng StartLocation { get; }

    /// <summary>
    /// Gets the end location of this step.
    /// </summary>
    public LatLng EndLocation { get; }

    /// <summary>
    /// Gets the instructions for this step with HTML formatting.
    /// </summary>
    public string HtmlInstructions { get; }
  }
}
