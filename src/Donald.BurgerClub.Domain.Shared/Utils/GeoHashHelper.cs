using NGeoHash;

namespace Donald.BurgerClub.Utils
{
    public static class GeoHashHelper
    {
        public static string ConvertToGeoHash(double latitude, double longitude)
        {
            return GeoHash.Encode(latitude, longitude);
        }

        public static (double latitude, double longitude) ConvertToLocation(string geoHashValue)
        {
            var decoded = GeoHash.Decode(geoHashValue);
            var latitude = decoded.Coordinates.Lat;
            var longitude = decoded.Coordinates.Lon;
            return (latitude, longitude);
        }
    }
}
