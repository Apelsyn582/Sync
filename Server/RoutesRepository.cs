

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
                Owner = new() { Name = "Іван", Phone = "+380676680971", Password = "1234" },
                fellow_travelers = new()
                {
                    new(){Name = "Іванка", Phone = "+380676686593", Password = "1234"},
                    new(){Name = "Наталя", Phone = "+380098696740", Password = "1234"},
                    new(){Name = "Олег", Phone = "+380674356565", Password = "1234"},
                }
            },
            new()
            {
                StartPin = new(49.836910, 24.001949),
                EndPin = new(49.864880, 24.053089),
                Time = "14:15",
                Date = "16.04",
                Transport = "Taxi",
                Owner = new() { Name = "Степан", Phone = "+380676909631", Password = "1234" },
                fellow_travelers = new()
                {
                    new(){Name = "Іванка", Phone = "+380676686593", Password = "1234"},
                    new(){Name = "Наталя", Phone = "+380098696740", Password = "1234"},
                    new(){Name = "Олег", Phone = "+380674356565", Password = "1234"},
                }
            },
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
        public static void DeleteRoute(Route route)
        {
            routes.Remove(route);
        }

    }
}
