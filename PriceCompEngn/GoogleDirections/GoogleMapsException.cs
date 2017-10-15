using System;

namespace GoogleDirections
{
  /// <summary>
  /// Exception thrown if a request to the Google Maps API fails
  /// </summary>
  public sealed class GoogleMapsException : Exception
  {
    internal GoogleMapsException(string message) : base(message)
    {

    }
  }
}
