using Project2024.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2024.LocalBase
{
    public static class UserRoute
    {
        private readonly static Route route = new()
        {
            StartPin = new _Pin(),
            EndPin = new _Pin(),
            Time = "99:99",
            Owner = new User()
        };

        public static _Pin GetStartPin()
        {
            return route.StartPin;
        }

        public static _Pin GetEndPin()
        {
            return route.EndPin;
        }

        public static string GetTime() 
        {
            return route.Time;
        }
        public static User GetOwner()
        {
            return route.Owner;
        }

        public static void SetStartPin(double latitude, double longitude)
        {

            if (latitude != 0 && longitude != 0)
            {
                route.StartPin.Latitude = latitude;
                route.StartPin.Longitude = longitude;
            }
        }

        public static void SetEndPin(double latitude, double longitude)
        {

            if (latitude != 0 && longitude != 0)
            {
                route.EndPin.Latitude = latitude;
                route.EndPin.Longitude = longitude;
            }
        }

        public static void SetTime(string time)
        {
            if (time != null)
            {
                route.Time = time;
            }
        }

        public static void SetOwner()
        {

        }
    }
}
