using server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace server
{
    [Serializable]
    public class Message
    {
        public string username { get; set; }
        public int token { get; set; }
        public string text { get; set; }
        public DateTime time { get; set; }
        public Message()
        {
            this.username = "Server";
            this.token = 0;
            this.text = "Server is running...";
            this.time = DateTime.UtcNow;
        }
        public Message(string username, int token, string text)
        {
            this.username = username;
            this.token = token;
            this.text = text;
            this.time = DateTime.UtcNow;
        }
    }

    [Serializable]
    public class Messages
    {
        public List<Message> messages = new List<Message>();
        public Messages()
        {

        }
        public void Add(string username, int token, string text)
        {
            Message ms = new Message(username, token, text);
            messages.Add(ms);
        }
        public void Add(Message ms)
        {
            messages.Add(ms);
        }
    }

    [Serializable]
    public class UserData
    {
        public string login { get; set; }
        public string password { get; set; }
        public UserData()
        {

        }
        public UserData(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
    }

    [Serializable]
    public class Session
    {
        public int token { get; set; }
        public string login { get; set; }
        public int online { get; set; }
        public Session()
        {

        }
        public Session(int token, string login)
        {
            this.token = token;
            this.login = login;
            this.online = 1;
        }
    }

    [Serializable]
    public class DeleteMessageData
    {
        public string login { get; set; }
        public int token { get; set; }
        public int messageID { get; set; }
        public DeleteMessageData()
        {

        }
        public DeleteMessageData(string login, int token, int messageID)
        {
            this.login = login;
            this.token = token;
            this.messageID = messageID;
        }
    }
}
