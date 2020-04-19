using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Api.Controllers
{
    [Microsoft.AspNetCore.Components.Route("[controller]")]
    public abstract class ApiControllerBase : Controller
    {
        protected readonly ICommandDispatcher CommandDispatcher;

        protected ApiControllerBase(ICommandDispatcher commandDispatcher)
        {            
            CommandDispatcher = commandDispatcher;
        }
    }
}
