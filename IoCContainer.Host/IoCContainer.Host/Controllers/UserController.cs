using IoCContainer.Host.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IoCContainer.Host.Controllers
{
    public class UserController
    {
        public UserController(ICalculator calc, IEmailService email)
        {

        }




    }
}