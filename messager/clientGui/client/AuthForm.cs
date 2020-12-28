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

namespace client
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
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

        private void btnReg_Click(object sender, EventArgs e)
        {
            if (fieldUsername2.Text.Length != 0 && fieldPassword2.Text.Length != 0)
            {
                if (fieldPassword2.Text != fieldPassword3.Text)
                {
                    MessageBox.Show("Пароли не совпадают");
                }
                else if (Registration(fieldUsername2.Text, fieldPassword2.Text) == -1)
                {
                    MessageBox.Show("Такой пользователь уже зарегистрирован");
                }
                else
                {
                    int token = Authorization(fieldUsername2.Text, fieldPassword2.Text);
                    MainForm Main = new MainForm();
                    Main.Auth = this;
                    Main.Show();
                    Main.TextBoxUsername.Text = fieldUsername2.Text;
                    Main.token = token;
                    fieldUsername1.Clear();
                    fieldPassword1.Clear();
                    fieldUsername2.Clear();
                    fieldPassword2.Clear();
                    fieldPassword3.Clear();
                    this.Visible = false;
                }
            }
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            if (fieldUsername1.Text.Length != 0 && fieldPassword1.Text.Length != 0)
            {
                int token = Authorization(fieldUsername1.Text, fieldPassword1.Text);
                if (token == -1)
                {
                    MessageBox.Show("Пользователь не найден");
                }
                else if (token == -2)
                {
                    MessageBox.Show("Неверный пароль");
                }
                else
                {
                    MainForm Main = new MainForm();
                    Main.Auth = this;
                    Main.Show();
                    Main.TextBoxUsername.Text = fieldUsername1.Text;
                    Main.token = token;
                    fieldUsername1.Clear();
                    fieldPassword1.Clear();
                    fieldUsername2.Clear();
                    fieldPassword2.Clear();
                    fieldPassword3.Clear();
                    this.Visible = false;
                }
            }
        }
    }
}