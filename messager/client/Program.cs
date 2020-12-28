using System;
using Terminal.Gui;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.Timers;
using server;

namespace ConsoleClient
{
    class Program
    {
        private static MenuBar menu;
        private static Window winMain;
        private static Window winMessages;
        private static Label labelUsername;
        private static Label labelPassword;
        private static Label labelMessage;
        private static TextField fieldUsername;
        private static TextField fieldPassword;
        private static TextField fieldMessage;
        private static Button btnSend;
        private static Button btnAuth;

        public static Messages AllMessages = new Messages();
        public static int token = -5;

        static void Main(string[] args)
        {
            Application.Init();


            menu = new MenuBar(new MenuBarItem[]
            {
                new MenuBarItem("_App", new MenuItem[]
                {
                    new MenuItem("_Quite", "Close the app", Application.RequestStop),
                })
            })
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = 1,
            };
            Application.Top.Add(menu);

            winMain = new Window()
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
                Title = "chat"
            };
            winMain.ColorScheme = Terminal.Gui.Colors.Error;
            Application.Top.Add(winMain);

            winMessages = new Window()
            {
                X = 0,
                Y = 0,
                Width = winMain.Width,
                Height = winMain.Height - 3,
            };
            winMessages.ColorScheme = Terminal.Gui.Colors.Error;
            winMain.Add(winMessages);

            labelUsername = new Label()
            {
                X = 0,
                Y = Pos.Bottom(winMain) - 6,
                Width = 15,
                Height = 1,
                Text = "Username: ",
                TextAlignment = TextAlignment.Right,
            };
            winMain.Add(labelUsername);

            labelPassword = new Label()
            {
                X = 0,
                Y = Pos.Bottom(winMain) - 5,
                Width = 15,
                Height = 1,
                Text = "Password: ",
                TextAlignment = TextAlignment.Right,
            };
            winMain.Add(labelPassword);

            labelMessage = new Label()
            {
                X = 0,
                Y = Pos.Bottom(winMain) - 4,
                Width = 15,
                Height = 1,
                Text = "Message: ",
                TextAlignment = TextAlignment.Right,
            };
            winMain.Add(labelMessage);

            fieldUsername = new TextField()
            {
                X = 15,
                Y = Pos.Bottom(winMain) - 6,
                Width = winMain.Width - 15,
                Height = 1,
            };
            winMain.Add(fieldUsername);

            fieldPassword = new TextField()
            {
                X = 15,
                Y = Pos.Bottom(winMain) - 5,
                Width = winMain.Width - 15,
                Height = 1,
            };
            winMain.Add(fieldPassword);

            fieldMessage = new TextField()
            {
                X = 15,
                Y = Pos.Bottom(winMain) - 4,
                Width = winMain.Width - 15,
                Height = 1,
            };
            winMain.Add(fieldMessage);

            btnSend = new Button()
            {
                X = Pos.Right(winMain) - 15,
                Y = Pos.Bottom(winMain) - 4,
                Width = 15,
                Height = 1,
                Text = " SEND ",
            };
            btnSend.Clicked += OnBtnSendClick;
            winMain.Add(btnSend);

            btnAuth = new Button()
            {
                X = Pos.Right(winMain) - 15,
                Y = Pos.Bottom(winMain) - 6,
                Width = 15,
                Height = 1,
                Text = " Auth ",
            };
            btnAuth.Clicked += OnBtnAuthClick;
            winMain.Add(btnAuth);

            int lastMsgID = 0;
            int lastMsgDeleteID = 0;

            Timer timerMessage = new Timer();
            timerMessage.Interval = 200;

            Timer timerOnline = new Timer();
            timerOnline.Interval = 500;

            Timer timerDelete = new Timer();
            timerDelete.Interval = 1000;

            timerMessage.Elapsed += (object sender, ElapsedEventArgs e) =>
            {
                Message msg = GetMessage(lastMsgID);
                if (msg != null)
                {
                    AllMessages.Add(msg);
                    lastMsgID++;
                    MessagesUpdate();
                }
            };

            timerDelete.Elapsed += (object sender, ElapsedEventArgs e) =>
            {
                int IDdeleteMsg = GetDeleteMessage(lastMsgDeleteID);
                {
                    if (IDdeleteMsg != -1)
                    {
                        lastMsgDeleteID++;
                        for (int i = 0; i < AllMessages.messages.Count; i++)
                        {
                            if (IDdeleteMsg == i)
                            {
                                Message message = GetMessage(IDdeleteMsg);
                                AllMessages.messages[i].text = message.text;
                                AllMessages.messages[i].username = message.username;
                                AllMessages.messages[i].token = message.token;
                            }
                        }
                        MessagesUpdate();
                    }
                }
            };

            timerOnline.Elapsed += (object sender, ElapsedEventArgs e) =>
            {
                if (token > 0)
                {
                    SendOnline(new Session(token, fieldUsername.Text.ToString()));
                }
            };

            timerOnline.Start();
            timerMessage.Start();
            timerDelete.Start();

            Application.Run();

            static void OnBtnAuthClick()
            {
                if (fieldUsername.Text.Length != 0 && fieldPassword.Text.Length != 0)
                {
                    token = Authorization(fieldUsername.Text.ToString(), fieldPassword.Text.ToString());
                    if (token == -1)
                    {
                        Registration(fieldUsername.Text.ToString(), fieldPassword.Text.ToString());
                        token = Authorization(fieldUsername.Text.ToString(), fieldPassword.Text.ToString());
                        fieldUsername.ReadOnly = true;
                        fieldPassword.ReadOnly = true;
                        fieldMessage.Text = "";
                    }
                    else if (token == -2)
                    {                        
                        fieldMessage.Text = "Неверный пароль";
                    }
                    else
                    {
                        fieldUsername.ReadOnly = true;
                        fieldPassword.ReadOnly = true;
                        fieldMessage.Text = "";
                    }
                }
            }

            static void OnBtnSendClick()
            {
                    SendMessage(new Message(fieldUsername.Text.ToString(), token, fieldMessage.Text.ToString()));
                    fieldMessage.Text = "";
            }
        }

        static void MessagesUpdate()
        {
            winMessages.RemoveAll();
            int offset = 0;
            for (var i = AllMessages.messages.Count - 1; i >= 0; i--)
            {
                View msg = new View()
                {
                    X = 0,
                    Y = offset,
                    Width = winMessages.Width,
                    Height = 1,
                    Text = $"[{AllMessages.messages[i].username}] {AllMessages.messages[i].text}",
                };
                winMessages.Add(msg);
                offset++;
            }
            Application.Refresh();
        }

        static int Authorization(string login, string password)
        {
            UserData userData = new UserData(login, password);
            WebRequest httpWebRequest = WebRequest.Create("http://localhost:5000/api/auth");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            string postData = JsonConvert.SerializeObject(userData);
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            httpWebRequest.ContentLength = bytes.Length;
            Stream reqStream = httpWebRequest.GetRequestStream();
            reqStream.Write(bytes, 0, bytes.Length);
            int resp;
            using (var response = (HttpWebResponse)httpWebRequest.GetResponse())
                resp = Convert.ToInt32(new StreamReader(response.GetResponseStream()).ReadToEnd());
            reqStream.Close();
            return resp;
        }

        static int Registration(string login, string password)
        {
            UserData userData = new UserData(login, password);
            WebRequest httpWebRequest = WebRequest.Create("http://localhost:5000/api/reg");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            string postData = JsonConvert.SerializeObject(userData);
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            httpWebRequest.ContentLength = bytes.Length;
            Stream reqStream = httpWebRequest.GetRequestStream();
            reqStream.Write(bytes, 0, bytes.Length);
            int resp;
            using (var response = (HttpWebResponse)httpWebRequest.GetResponse())
                resp = Convert.ToInt32(new StreamReader(response.GetResponseStream()).ReadToEnd());
            reqStream.Close();
            return resp;
        }

        static void SendMessage(Message msg)
        {
            WebRequest httpWebRequest = WebRequest.Create("http://localhost:5000/api/chat");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            string postData = JsonConvert.SerializeObject(msg);
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            httpWebRequest.ContentLength = bytes.Length;
            Stream reqStream = httpWebRequest.GetRequestStream();
            reqStream.Write(bytes, 0, bytes.Length);
            reqStream.Close();
            httpWebRequest.GetResponse();
        }

        static Message GetMessage(int id)
        {
            WebRequest httpWebRequest = WebRequest.Create($"http://localhost:5000/api/chat/{id}");
            WebResponse httpWebResponse = httpWebRequest.GetResponse();
            string smsg = new StreamReader(httpWebResponse.GetResponseStream()).ReadToEnd();
            if (smsg == "not found")
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Message>(smsg);
        }

        static int GetDeleteMessage(int id)
        {
            WebRequest httpWebRequest = WebRequest.Create($"http://localhost:5000/api/del/{id}");
            WebResponse httpWebResponse = httpWebRequest.GetResponse();
            string smsg = new StreamReader(httpWebResponse.GetResponseStream()).ReadToEnd();
            int IDdeleteMsg = Convert.ToInt32(smsg);
            return IDdeleteMsg;
        }

        static void SendOnline(Session session)
        {
            WebRequest httpWebRequest = WebRequest.Create("http://localhost:5000/api/online");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            string postData = JsonConvert.SerializeObject(session);
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            httpWebRequest.ContentLength = bytes.Length;
            Stream reqStream = httpWebRequest.GetRequestStream();
            reqStream.Write(bytes, 0, bytes.Length);
            reqStream.Close();
            httpWebRequest.GetResponse();
        }
    }
}