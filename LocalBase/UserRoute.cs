using Project2024.Server;
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
            StartPin = new _Pin(0,0),
            EndPin = new _Pin(0,0),
            Time = "99:99",
            Date = "16.04",
            Transport = "Taxi",
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
        public static string GetDate()
        {
            return route.Date;
        }

        public static string GetTransport()
        {
            return route.Transport;
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

        public static void SetDate(string date)
        {
            if (date != null)
            {
                route.Date = date;
            }
        }

        public static void SetTransport(string transport)
        {
            if (transport != null)
            {
                route.Transport = transport;
            }
        }

        public static void SetOwner(User user)
        {
            route.Owner = user;
        }

        public static void AddName(string name)
        {
            route.Owner.Name = name;
        }
    }
}
