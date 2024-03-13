using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2024.SqlServer
{
    public class Route
    {
        public required Pin StartPin { get; set; }

        public required Pin EndPin { get; set; }
    }
}
