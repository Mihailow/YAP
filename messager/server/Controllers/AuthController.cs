using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // POST api/<AuthController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public int Post([FromBody] UserData userData)
        {
            for (int i = 0; i < Program.Users.users.Count; i++)
            {
                if (Program.Users.users[i].login == userData.login)
                    if (Program.Users.users[i].password == userData.password)
                    {
                        int token = Program.Sessions.GenToken();
                        for (int j = 0; j < Program.Sessions.sessions.Count; j++)
                        {
                            if (Program.Sessions.sessions[j].login == userData.login)
                            {
                                Program.Sessions.sessions[j].token = token;
                                Console.WriteLine($"Пользователь {userData.login} вошёл. Токен: {token}");
                                Program.Messages.Add("Server", 0, $"Пользователь {userData.login} зашёл в чат");
                                return token;
                            }
                        }
                        Program.Sessions.Add(token, userData.login);
                        Console.WriteLine($"Пользователь {userData.login} вошёл. Токен: {token}");
                        Program.Messages.Add("Server", 0, $"Пользователь {userData.login} зашёл в чат");
                        return token;
                    }
                    else return -2;
            }
            return -1;
        }
    }
}
