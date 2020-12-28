using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class chatController : ControllerBase
    {
        // GET api/<chatController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public string Get()
        {
            string all = "";
            string json;
            for (int i = Program.Messages.messages.Count - 1; i >= 0; i--)
            {
                json = JsonSerializer.Serialize(Program.Messages.messages.ElementAt(i));
                all = all + json.ToString() + "\n";
            }
            return all;
        }

        // GET api/<chatController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public string Get(int id)
        {
            string json = "not found";
            if ((id < Program.Messages.messages.Count) && (id >= 0))
            {
                json = JsonSerializer.Serialize(Program.Messages.messages.ElementAt(id));
            }
            return json.ToString();
        }

        // POST api/<chatController>
        [HttpPost]
        public void Post([FromBody] Message message)
        {
            for (int j = 0; j < Program.Sessions.sessions.Count; j++)
            {
                if (Program.Sessions.sessions[j].token == message.token)
                {
                    Program.Messages.Add(message.username, message.token, message.text);
                    Console.WriteLine($"{message.username} отправил сообщение: '{message.text}' ");
                    return;
                }
            }
        }
    }
}
