﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using GeoLib.Services;

namespace GeoLib.ConsoleHost1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostGeoManager = new ServiceHost(typeof(GeoManager));

            hostGeoManager.Open();

            Console.WriteLine("Services started on Console Host 1 . Press [Enter] to exit.");
            Console.ReadLine();

            hostGeoManager.Close();
        }
    }
}
