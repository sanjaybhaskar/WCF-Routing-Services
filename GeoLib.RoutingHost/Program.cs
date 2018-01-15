using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Routing;

namespace GeoLib.RoutingHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost routingHost = new ServiceHost(typeof(RoutingService));
            routingHost.Open();

            Console.WriteLine("Routing Services running.");
            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();
        }
    }

    public class CustomContentFilter : MessageFilter
    {
        public CustomContentFilter(string filterData)
        {
            _FilterData = filterData;
        }

        string _FilterData;

        public override bool Match(Message message)
        {
            bool ret = false;

            if (message.ToString().IndexOf("<state>" + _FilterData + "</state>") > -1)
                ret = true;

            return ret;
        }

        public override bool Match(MessageBuffer buffer)
        {
            throw new NotImplementedException();
        }
    }
}
