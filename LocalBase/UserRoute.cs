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

        private static readonly _Pin StartPin = new(0, 0);
        private static readonly _Pin EndPin = new(0, 0);
        private static string Time = "99:99";
        private static string Date = "16.04";
        private static string Transport = "Taxi";
        private static User Owner = new();
        private static List<Route> MyRoutes = new List<Route>()
        {
            new()
            {
                StartPin = new(49.836910, 24.001949),
                EndPin = new(49.864880, 24.053089),
                Time = "14:15",
                Date = "16.04",
                Transport = "Taxi",
                Owner = new() { Name = "jghbh", Phone = "+380676680971"},
                fellow_travelers = new()
                {
                    new(){Name = "Іванка", Phone = "+380676686593"},
                    new(){Name = "Наталя", Phone = "+380098696740"},
                    new(){Name = "Олег", Phone = "+380674356565"},
                }
            },
            new()
            {
                StartPin = new(49.836910, 24.001949),
                EndPin = new(49.864880, 24.053089),
                Time = "14:15",
                Date = "16.04",
                Transport = "Taxi",
                Owner = new() { Name = "fsgddgh", Phone = "+380676909631"},
                fellow_travelers = new()
                {
                    new(){Name = "Іванка", Phone = "+380676686593", Password = "1234"},
                    new(){Name = "Наталя", Phone = "+380098696740", Password = "1234"},
                    new(){Name = "Олег", Phone = "+380674356565", Password = "1234"},
                }
            },
        };
        private static List<Route> ActiveRoutes = new List<Route>()
        { new()
            {
                StartPin = new(49.836910, 24.001949),
                EndPin = new(49.864880, 24.053089),
                Time = "14:15",
                Date = "16.04",
                Transport = "Taxi",
                Owner = new() { Name = "чван", Phone = "+380676680971"},
                fellow_travelers = new()
                {
                    new(){Name = "Іванка", Phone = "+380676686593"},
                    new(){Name = "Наталя", Phone = "+380098696740"},
                    new(){Name = "Олег", Phone = "+380674356565"},
                }
            },
            new()
            {
                StartPin = new(49.836910, 24.001949),
                EndPin = new(49.864880, 24.053089),
                Time = "14:15",
                Date = "16.04",
                Transport = "Taxi",
                Owner = new() { Name = "ьтепан", Phone = "+380676909631"},
                fellow_travelers = new()
                {
                    new(){Name = "Іванка", Phone = "+380676686593", Password = "1234"},
                    new(){Name = "Наталя", Phone = "+380098696740", Password = "1234"},
                    new(){Name = "Олег", Phone = "+380674356565", Password = "1234"},
                }
            },
        };
            
        private static List<Route> LastRoutes = new List<Route>();


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

        public static List<Route> GetMyRoutes()
        {
            return MyRoutes;
        }

        public static List<Route> GetActiveRoutes()
        {
            return ActiveRoutes;
        }

        public static List<Route> GetLastRoutes()
        {
            return LastRoutes;
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

        public static void AddMyRoute(Route route)
        {
            MyRoutes.Add(route);
        }
        public static void RemoveMyRoute(Route route)
        {
            MyRoutes.Remove(route);
        }
        public static void AddActiveRoute(Route route)
        {
            ActiveRoutes.Add(route);
        }
        public static void AddLastRoute(Route route)
        {
            LastRoutes.Add(route);
        }


    }
}
