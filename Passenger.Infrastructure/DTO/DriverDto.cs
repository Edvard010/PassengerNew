﻿using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Infrastructure.DTO
{
    public class DriverDto
    {
        public Guid UserId { get; set; }
        public Vehicle Vehicle { get; set; } //VehicleDto
        public IEnumerable<Route> Routes { get; set; }
        public IEnumerable<DailyRoute> DailyRoutes { get; set; }
    }
}
