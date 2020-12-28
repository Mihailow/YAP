using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        string AdminPassword = "Mihalich-zver";
        // POST api/<AdminController>
        [HttpPost]
        public int Post([FromBody] UserData userData)
        {
            if (userData.password == AdminPassword)
            {
                Program.Admin.Add(0, userData.login);
                Console.WriteLine($"{userData.login} получил права администратора");
                return 1;
            }
            else
                return 0;
        }
    }
}
