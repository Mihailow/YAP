using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using server;
using Message = server.Message;

namespace client
{
    public partial class MainForm : Form
    {
        public AuthForm Auth;
        public TextBox TextBoxUsername;

        Messages AllMessages = new Messages();
        int lastMsgID = 0;
        int lastMsgDeleteID = 0;
        public int token;
        bool ViewMessageID = false;
        static void SendMessage(Message message)
        {
            WebRequest httpWebRequest = WebRequest.Create("http://localhost:5000/api/chat");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            string postData = JsonConvert.SerializeObject(message);
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            httpWebRequest.ContentLength = bytes.Length;
            Stream reqStream = httpWebRequest.GetRequestStream();
            reqStream.Write(bytes, 0, bytes.Length);
            reqStream.Close();
            httpWebRequest.GetResponse();
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
        static void SendDeleteMessage(DeleteMessageData deleteMessageData)
        {
            WebRequest httpWebRequest = WebRequest.Create("http://localhost:5000/api/del");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            string postData = JsonConvert.SerializeObject(deleteMessageData);
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            httpWebRequest.ContentLength = bytes.Length;
            Stream reqStream = httpWebRequest.GetRequestStream();
            reqStream.Write(bytes, 0, bytes.Length);
            reqStream.Close();
            httpWebRequest.GetResponse();
        }
        static int SendAdminPassword(UserData userData)
        {
            WebRequest httpWebRequest = WebRequest.Create("http://localhost:5000/api/admin");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            string postData = JsonConvert.SerializeObject(userData);
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            httpWebRequest.ContentLength = bytes.Length;
            Stream reqStream = httpWebRequest.GetRequestStream();
            reqStream.Write(bytes, 0, bytes.Length);
            reqStream.Close();
            using (var response = (HttpWebResponse)httpWebRequest.GetResponse())
                return Convert.ToInt32(new StreamReader(response.GetResponseStream()).ReadToEnd());
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
        public void ChoiceEmoji(object sender, EventArgs e)
        {
            fieldMessage.Text += (sender as Button).Text;
        }
        public void MessagesUpdate()
        {
            listMessages.Items.Clear();
            for (int i = 0; i < AllMessages.messages.Count; i++)
            {
                if (ViewMessageID == false)
                {
                    if (AllMessages.messages[i].username == "Server")
                        listMessages.Items.Add($"{(AllMessages.messages[i].time)}\t\t{AllMessages.messages[i].text}");
                    else
                        listMessages.Items.Add($"{(AllMessages.messages[i].time)}\t\t[{AllMessages.messages[i].username}]\t\t{AllMessages.messages[i].text}");
                }
                else
                {
                    if (AllMessages.messages[i].username == "Server")
                        listMessages.Items.Add($"[ ID:{i} ] {(AllMessages.messages[i].time)}\t\t{AllMessages.messages[i].text}");
                    else
                        listMessages.Items.Add($"[ ID:{i} ] {(AllMessages.messages[i].time)}\t\t[{AllMessages.messages[i].username}]\t\t{AllMessages.messages[i].text}");
                }
            }
        }
        public MainForm()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            token = 0;
            TextBoxUsername = fieldUsername;
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Auth.Show();
        }
        private void timerMessage_Tick(object sender, EventArgs e)
        {
            Message msg = GetMessage(lastMsgID);
            if (msg != null)
            {
                AllMessages.Add(msg);
                lastMsgID++;
                MessagesUpdate();
            }
        }

        private void timerDelete_Tick(object sender, EventArgs e)
        {
            int IDdeleteMsg = GetDeleteMessage(lastMsgDeleteID);
            {
                if (IDdeleteMsg != -1)
                {
                    lastMsgDeleteID++;
                    listMessages.Items.Clear();
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
        }
        private void timerOnline_Tick(object sender, EventArgs e)
        {
            SendOnline(new Session(token, fieldUsername.Text));
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (fieldMessage.Text.Length < 1)
                return;
            if (fieldMessage.Text.Contains("/delete"))
            {
                int MessageID;
                int.TryParse(string.Join("", fieldMessage.Text.Where(c => char.IsDigit(c))), out MessageID);
                DeleteMessageData deleteMessageData = new DeleteMessageData(fieldUsername.Text, token, MessageID);
                SendDeleteMessage(deleteMessageData);
                fieldMessage.Clear();
            }
            else
            {
                SendMessage(new Message(fieldUsername.Text, token, fieldMessage.Text));
                fieldMessage.Clear();
            }
        }    
        private void btnAuth_Click(object sender, EventArgs e)
        {
            Auth.Show();
            this.Visible = false;
        }
        private void btnEmoji_Click(object sender, EventArgs e)
        {
            if (panelEmoji.Visible == false)
                 panelEmoji.Visible = true;
            else
                panelEmoji.Visible = false;
        }
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (SendAdminPassword(new UserData(fieldUsername.Text, fieldSecret.Text)) == 1)
            {
                ViewMessageID = true;
                MessagesUpdate();
            }
        }
    }
}
