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

        private static _Pin StartPin = new(0, 0);
        private static _Pin EndPin = new(0, 0);
        private static string Time = "99:99";
        private static string Date = "16.04";
        private static string Transport = "Taxi";
        private static User Owner = new();
       

        public static _Pin GetStartPin()
        {
            return StartPin;
        }

        public static _Pin GetEndPin()
        {
            return EndPin;
        }

        public static string GetTime() 
        {
            return Time;
        }
        public static string GetDate()
        {
            return Date;
        }

        public static string GetTransport()
        {
            return Transport;
        }
        public static User GetOwner()
        {
            return Owner;
        }

        public static void SetStartPin(double latitude, double longitude)
        {

            if (latitude != 0 && longitude != 0)
            {
                StartPin.Latitude = latitude;
                StartPin.Longitude = longitude;
            }
        }

        public static void SetEndPin(double latitude, double longitude)
        {

            if (latitude != 0 && longitude != 0)
            {
                EndPin.Latitude = latitude;
                EndPin.Longitude = longitude;
            }
        }

        public static void SetTime(string time)
        {
            if (time != null)
            {
                Time = time;
            }
        }

        public static void SetDate(string date)
        {
            if (date != null)
            {
                Date = date;
            }
        }

        public static void SetTransport(string transport)
        {
            if (transport != null)
            {
                Transport = transport;
            }
        }

        public static void SetOwner(User user)
        {
            Owner = user;
        }

        public static void AddName(string name)
        {
            Owner.Name = name;
        }
    }
}
