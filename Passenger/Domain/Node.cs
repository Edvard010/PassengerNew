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
        public DateTime UpdatedAt { get; protected set; }
        protected Node()
        {
        }
        protected Node(string address, double longtitude, double latitude)
        {
            SetAddress(address);
            SetLongtitude(longtitude);
            SetLatitude(latitude);
        }
        public void SetAddress(string address)
        {
            Address = address;
            UpdatedAt = DateTime.UtcNow;
        }
        public void SetLongtitude(double longtitude)
        {
            if (double.IsNaN(longtitude))
            {
                throw new Exception("Longtitude must be a number");
            }
            if (Longtitude == longtitude)
            {
                return;
            }
            Longtitude = longtitude;
            UpdatedAt = DateTime.UtcNow;

        }
        public void SetLatitude(double latitude)
        {
            if (double.IsNaN(latitude))
            {
                throw new Exception("Latitude must be a number");
            }
            if (Latitude == latitude)
            {
                return;
            }
            Latitude = latitude;
            UpdatedAt = DateTime.UtcNow;

        }
    }
}
