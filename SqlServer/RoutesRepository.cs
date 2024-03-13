using Project2024.LocalBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2024.SqlServer
{
    public class RoutesRepository
    {
        public List<Route> routes = new()
        {
            
        };

        public void AddRoute(Route route)
        {
            routes.Add(route); 
        }
        public void DeleteRoute(Route route)
        {
            routes.Remove(route);
        }

    }
}
