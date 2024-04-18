using Microsoft.Maui.Devices.Sensors;
using Project2024.LocalBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2024.Server
{
    public static class RoutesRepository
    {
        public static List<Route> routes = new()
        {
            new()
            {
                StartPin = new(49.836910, 24.001949),
                EndPin = new(49.864880, 24.053089),
                Time = "14:15",
                Date = "16.04",
                Transport = "Taxi",
                Owner = new() { Name = "Іван", Phone = "+380676680971", Password = "1234" }
            },
            new()
            {
                StartPin = new(49.898910, 24.881949),
                EndPin = new(49.877880, 24.053089),
                Time = "14:15",
                Date = "16.04",
                Transport = "Taxi",
                Owner = new() { Name = "Степан", Phone = "+380676680971", Password = "1234" }
            },
        };


        public static Route GetRouteByOwnerName(string name)
        { 
            foreach (var route in routes)
            {
                if (route.Owner.Name == name)
                {
                    return route;
                }
            }
            return null;
        }

        public static List<Route> GetListWithFellowTravelers(Location StartLocation, Location EndLocation)
        {
            List<Route> _routes = new()
            {

            };

            foreach (var route in routes)
            {

                var dis_between_starts = Location.CalculateDistance(new Location(route.StartPin.Latitude, route.StartPin.Longitude), StartLocation, DistanceUnits.Miles);

                var dis_between_ends = Location.CalculateDistance(new Location(route.EndPin.Latitude, route.EndPin.Longitude), EndLocation, DistanceUnits.Miles);

                if (dis_between_starts < 0.1864 && dis_between_ends < 0.1864)
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
