using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelController : ControllerBase
    {
        // GET api/<DelController>/5
        [HttpGet("{id}")]
        public int Get(int id)
        {
            if ((id < Program.DeletedMessages.Count) && (id > -1))
                return Program.DeletedMessages[id];
            else
                return -1;
        }

        // POST api/<DelController>
        [HttpPost]
        public void Post([FromBody] DeleteMessageData deleteMessageData)
        {
            for (int i = 0; i < Program.Admin.sessions.Count; i++)
            {
                if (Program.Admin.sessions[i].login == deleteMessageData.login)
                {
                    Program.DeletedMessages.Add(deleteMessageData.messageID);
                    Console.WriteLine($"Admin {deleteMessageData.login} delete message ID = {deleteMessageData.messageID}");

                    Message OldMessage = new Message();
                    OldMessage.username = Program.Messages.messages[deleteMessageData.messageID].username;
                    OldMessage.text = Program.Messages.messages[deleteMessageData.messageID].text;
                    OldMessage.token = Program.Messages.messages[deleteMessageData.messageID].token;
                    OldMessage.time = Program.Messages.messages[deleteMessageData.messageID].time;


                    Program.Messages.messages[deleteMessageData.messageID].username = "Server";
                    Program.Messages.messages[deleteMessageData.messageID].text = "Сообщение было удалено администратором";
                    Program.Messages.messages[deleteMessageData.messageID].token = 0;

                    string strAllMessages = System.IO.File.ReadAllText("SavedMessages.txt");
                    strAllMessages = strAllMessages.Replace(JsonConvert.SerializeObject(OldMessage).ToString(), JsonConvert.SerializeObject(Program.Messages.messages[deleteMessageData.messageID]).ToString());
                    System.IO.File.WriteAllText("SavedMessages.txt", strAllMessages);
                }
            }
        }
    }
}
