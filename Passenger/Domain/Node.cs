using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Core.Domain
{
    public class Node //to jest value object
    {
        public string Address { get; protected set; }
        public double Longtitude { get; protected set; }
        public double Latitude { get; protected set; }
    }
}
