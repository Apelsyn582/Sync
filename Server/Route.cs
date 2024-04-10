using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2024.Server
{
    public class Route
    {
        public required _Pin StartPin { get; set; }

        public required _Pin EndPin { get; set; }

        public required string Time { get; set; }

        public required User Owner { get; set; }
    }
}
