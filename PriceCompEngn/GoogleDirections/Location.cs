namespace GoogleDirections
{
  /// <summary>
  /// Class representing a location, defined by name and/or by latitude/longitude
  /// </summary>
  public sealed class Location
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Location"/> class.
    /// </summary>
    /// <param name="locationName">Name of the location.</param>
    public Location(string locationName)
    {
      LocationName = locationName;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Location"/> class.
    /// </summary>
    /// <param name="latLng">The latitude/longitude of the location.</param>
    public Location(LatLng latLng)
    {
      LatLng = latLng;
    }

    internal Location(LatLng latLng, string locationName)
    {
      LatLng = latLng;
      LocationName = locationName;
    }

    /// <summary>
    /// Gets the latitude/longitude of the location.
    /// </summary>
    public LatLng LatLng { get; }

    /// <summary>
    /// Gets the name/address of the location.
    /// </summary>
    /// <value>
    /// The name/address of the location.
    /// </value>
    public string LocationName { get; }

    /// <summary>
    /// Returns a <see cref="System.String"/> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="System.String"/> that represents this instance.
    /// </returns>
    public override string ToString()
    {
      if (LocationName !=  null)
        return LocationName;

      return LatLng.ToString();
    }
  }
}
