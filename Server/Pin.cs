﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2024.Server
{
    public class _Pin
    {
        public double Latitude { get; set; } = 0;
        public double Longitude { get; set; } = 0;

        public _Pin(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

    }
}
