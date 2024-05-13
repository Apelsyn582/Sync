

namespace Project2024.Server
{
    public static class RoutesRepository
    {
        public static List<Route> routes = new()
        {
            
        };

        public static List<User> GetFellowTravelers(string owner_name)
        {
            foreach (var route in routes)
            {
                if (route.Owner.Name == owner_name)
                {
                    return route.fellow_travelers;
                }
            }
            return null;
        }
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

        public static void AddFellowTraveler(string owner_name, User user)
        {
            foreach (var route in routes)
            {
                if (route.Owner.Name == owner_name)
                {
                    route.fellow_travelers.Add(user);
                }
            }
        }

        public static void RemoveFellowTraveler(string owner_name, User user)
        {
            foreach (var route in routes)
            {
                if (route.Owner.Name == owner_name)
                {
                    route.fellow_travelers.Remove(user);
                }
            }
        }
        public static void DeleteRoute(string owner_name, string time, string date)
        {
            for (int i = 0; i < routes.Count; i++)
            {
                if (routes[i].Owner.Name == owner_name && routes[i].Time == time && routes[i].Date == date)
                {
                    routes.Remove(routes[i]);
                }
            }

        }

    }
}
