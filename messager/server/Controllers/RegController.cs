using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegController : ControllerBase
    {
        // POST api/<RegController>
        [HttpPost]
        public int Post([FromBody] UserData userData)
        {
            for (int i = 0; i < Program.Users.users.Count; i++)
            {
                if (Program.Users.users[i].login == userData.login)
                {
                    return -1;
                }
            }
            Program.Users.Add(userData.login, userData.password);
            Console.WriteLine($"Добавлен новый пользователь {userData.login}");
            return 1;
        }
    }
}