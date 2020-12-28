using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineController : ControllerBase
    {
        // POST api/<OnlineController>
        [HttpPost]
        public void Post([FromBody] Session session)
        {
            for (int i = 0; i < Program.Sessions.sessions.Count; i++)
            {
                if ((Program.Sessions.sessions[i].login == session.login) && (Program.Sessions.sessions[i].token == session.token))
                    Program.Sessions.sessions[i].online = 1;
            }
        }
    }
}
