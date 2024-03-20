using Microsoft.Maui.Devices.Sensors;
using Project2024.LocalBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2024.SqlServer
{
    public static class RoutesRepository
    {
        public static List<Route> routes = new()
        {
            new()
            {
                StartPin = new _Pin(),
                EndPin = UserRoute.GetEndPin(),
                Time = UserRoute.GetTime(),
                Owner = new() { Name = "Іван", Phone = "+380676680971", Password = "1234" }
            },
        };


        public static List<Route> GetListWithFellowTravelers(Location StartLocation, Location EndLocation)
        {
            List<Route> _routes = new()
            {

            };

            foreach (var route in routes)
            {

                if (Location.CalculateDistance(new Location(route.StartPin.Latitude, route.StartPin.Longitude), StartLocation, DistanceUnits.Miles) < 200 && Location.CalculateDistance(new Location(route.EndPin.Latitude, route.EndPin.Longitude), EndLocation, DistanceUnits.Miles) < 200)
                {
                    _routes.Add(route);
                }
            }
            return _routes;
        }
        public static void AddRoute(Route route)
        {
            routes.Add(route); 
        }
        public static void DeleteRoute(Route route)
        {
            routes.Remove(route);
        }

    }
}
