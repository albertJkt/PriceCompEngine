using System.Globalization;
using System.Xml;

namespace GoogleDirections
{
  /// <summary>
  /// Class representing a latitude/longitude pair
  /// </summary>
  public sealed class LatLng
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="LatLng"/> class.
    /// </summary>
    /// <param name="latitude">The latitude.</param>
    /// <param name="longitude">The longitude.</param>
    public LatLng(double latitude, double longitude)
    {
      Latitude = latitude;
      Longitude = longitude;
    }

    internal LatLng(XmlElement locationElement)
    {
      Latitude = double.Parse(locationElement.SelectSingleNode("lat").InnerText, CultureInfo.InvariantCulture);
      Longitude = double.Parse(locationElement.SelectSingleNode("lng").InnerText, CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Gets the latitude.
    /// </summary>
    public double Latitude { get; }

    /// <summary>
    /// Gets the longitude.
    /// </summary>
    public double Longitude { get; }

    /// <summary>
    /// Returns a <see cref="System.String"/> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="System.String"/> that represents this instance.
    /// </returns>
    public override string ToString()
    {
      return Latitude.ToString() + ", " + Longitude.ToString();
    }
  }
}
