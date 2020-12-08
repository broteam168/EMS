using DevExpress.XtraMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Libs
{
    public static class GeoMath
    {
        const double EarthRadius = 6371;

        static double ToRadians(double value)
        {
            return value * Math.PI / 180;
        }
        static GeoPoint ToRadians(GeoPoint point)
        {
            return new GeoPoint(ToRadians(point.Latitude), ToRadians(point.Longitude));
        }
        public static double GetDistanceSphere(GeoPoint a, GeoPoint b)
        {
            GeoPoint aRad = ToRadians(a);
            GeoPoint bRad = ToRadians(b);

            double dLatitude = bRad.Latitude - aRad.Latitude;
            double dLongitude = bRad.Longitude - aRad.Longitude;

            double s = Math.Sin(dLatitude * 0.5) * Math.Sin(dLatitude * 0.5) +
                       Math.Sin(dLongitude * 0.5) * Math.Sin(dLongitude * 0.5) * Math.Cos(aRad.Latitude) * Math.Cos(bRad.Latitude);
            double c = 2 * Math.Atan2(Math.Sqrt(s), Math.Sqrt(1 - s));
            return EarthRadius * c;
        }
        public static double GetDistanceSphereSimple(GeoPoint a, GeoPoint b)
        {
            GeoPoint aRad = ToRadians(a);
            GeoPoint bRad = ToRadians(b);
            return Math.Acos(Math.Sin(aRad.Latitude) * Math.Sin(bRad.Latitude) +
                             Math.Cos(aRad.Latitude) * Math.Cos(bRad.Latitude) *
                             Math.Cos(bRad.Longitude - aRad.Longitude)) * EarthRadius;
        }
        public static double GetEquirectangularDistance(GeoPoint a, GeoPoint b)
        {
            GeoPoint aRad = ToRadians(a);
            GeoPoint bRad = ToRadians(b);

            double x = (bRad.Longitude - aRad.Longitude) * Math.Cos((aRad.Latitude + bRad.Latitude) * 0.5);
            double y = (aRad.Latitude - bRad.Latitude);
            return Math.Sqrt(x * x + y * y) * EarthRadius;
        }
    }
}
