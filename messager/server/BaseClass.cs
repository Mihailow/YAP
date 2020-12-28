using server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using server.Controllers;
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
    public class MessagesClass
    {
        public List<Message> messages = new List<Message>();
        public MessagesClass()
        {
            if (File.Exists("SavedMessages.txt"))
            {
                Message ms;
                string line;
                StreamReader file = new StreamReader("SavedMessages.txt");
                while ((line = file.ReadLine()) != null)
                {
                    ms = JsonConvert.DeserializeObject<Message>(line);
                    messages.Add(ms);
                    Console.WriteLine($"Сообщение: '{ms.text}' от {ms.username} загружено");
                }
                file.Close();
            }
        }
        void Add(Message ms)
        {
            messages.Add(ms);
            File.AppendAllText("SavedMessages.txt", JsonConvert.SerializeObject(ms).ToString() + "\n");
        }
        public void Add(string username, int token, string text)
        {
            Message ms = new Message(username, token, text);
            messages.Add(ms);
            File.AppendAllText("SavedMessages.txt", JsonConvert.SerializeObject(ms).ToString() + "\n");
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
    public class SessionsClass
    {
        public List<Session> sessions = new List<Session>();
        public SessionsClass()
        {

        }
        public int GenToken()
        {
            Random rand = new Random();
            return rand.Next(1000000, 9999999);
        }
        public void Add(int token, string login)
        {
            Session session = new Session(token, login);
            sessions.Add(session);
        }
        public int CheckData(int token, string login)
        {
            for (int i = 0; i < sessions.Count; i++)
            {
                if (sessions[i].login == login)
                    if (sessions[i].token == token)
                        return 1;
                    else
                        return -1;
            }
            return -1;
        }
    }

    [Serializable]
    public class Users
    {
        public List<UserData> users = new List<UserData>();
        public Users()
        {
            if (File.Exists("SavedUsers.txt"))
            {
                UserData userData;
                string line;
                StreamReader file = new StreamReader("SavedUsers.txt");
                while ((line = file.ReadLine()) != null)
                {
                    userData = JsonConvert.DeserializeObject<UserData>(line);
                    users.Add(userData);
                    Console.WriteLine($"Пользователь {userData.login} загружен");
                }
                file.Close();
            }
        }
        public void Add(string login, string password)
        {
            UserData userData = new UserData(login, password);
            users.Add(userData);
            File.AppendAllText("SavedUsers.txt", JsonConvert.SerializeObject(userData).ToString() + "\n");
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
