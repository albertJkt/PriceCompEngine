using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace GoogleDirections
{
  /// <summary>
  /// Wrapper round the Google Maps geocoding service
  /// </summary>
  public sealed class Geocoder : HttpWebService
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Geocoder"/> class.
    /// </summary>
    /// <param name="key">Your Google Maps API key.</param>
    public Geocoder(string key) : base(key)
    {
    }

    /// <summary>
    /// Reverses geocode the specified location.
    /// </summary>
    /// <param name="location">The location.</param>
    /// <returns>Returns the address of the location.</returns>
    /// <exception cref="System.Exception">Failed to find the address</exception>
    public string ReverseGeocode(LatLng location)
    {
      var response = MakeRequest(
        string.Format("{2}&latlng={0},{1}&sensor=false", 
        location.Latitude.ToString(CultureInfo.InvariantCulture), location.Longitude.ToString(CultureInfo.InvariantCulture), BaseUrl()));
      var responseXml = new XmlDocument();
      responseXml.LoadXml(response);
      var result = responseXml.SelectSingleNode("//result[type='street_address']/formatted_address");
      if (result == null)
        throw new Exception("Failed to find the address");
      return result.InnerText;
    }

    /// <summary>
    /// Reverses geocode the specified location.
    /// </summary>
    /// <param name="location">The location.</param>
    /// <returns>A dictionary of address components</returns>
    /// <exception cref="System.Exception">Failed to find the address</exception>
    public Dictionary<string, string> ReverseGeocodeComponents(LatLng location)
    {
      var response = MakeRequest(
        string.Format("{2}&latlng={0},{1}&sensor=false",
          location.Latitude.ToString(CultureInfo.InvariantCulture), location.Longitude.ToString(CultureInfo.InvariantCulture), BaseUrl()));
      var responseXml = new XmlDocument();
      responseXml.LoadXml(response);
      var result = responseXml.SelectNodes("//address_component");
      if (result == null || result.Count == 0)
        throw new Exception("Failed to find the address");

      var dictionary = new Dictionary<string, string>();
      for (var i = 0; i < result.Count; i++)
      {
        var type = result[i].SelectSingleNode("type").InnerText;
        var name = result[i].SelectSingleNode("long_name").InnerText;
        if (!dictionary.ContainsKey(type))
          dictionary.Add(type, name);
      }

      return dictionary;
    }

    /// <summary>
    /// Geocodes the specified address.
    /// </summary>
    /// <param name="address">The address.</param>
    /// <returns>An array of possible locations</returns>
    public IEnumerable<Location> Geocode(string address)
    {
      var response = MakeRequest(
        string.Format("{1}&address={0}&sensor=false", address, BaseUrl()));
      var responseXml = new XmlDocument();
      responseXml.LoadXml(response);
      var results = responseXml.SelectNodes("//result");
      var locations = new List<Location>();
      foreach (XmlElement result in results)
      {
        var formattedAddress = result.SelectSingleNode("formatted_address").InnerText;
        var locationElement = (XmlElement)result.SelectSingleNode("geometry/location");
        var latLng = new LatLng(locationElement);
        var location = new Location(latLng, formattedAddress);
        locations.Add(location);
      }

      return locations;
    }

    private string BaseUrl()
    {
      return string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key={0}", Key);
    }
  }
}
