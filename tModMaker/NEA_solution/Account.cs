using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_solution
{
    public partial class Account : Form
    {
        public string CurrentUser;
        public string token;
        private static readonly HttpClient client = new HttpClient();

        public Account(string CurrentUser)
        {
            this.CurrentUser = CurrentUser;
            InitializeComponent();

            if (CurrentUser != "")
            {
                lblDescription.Text = "Logged is as: " + CurrentUser;
            }
            else
            {
                lblDescription.Text = "Enter username and password:";
            }

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            try
            {
                using (var wb = new WebClient())
                {
                    var data = new NameValueCollection();
                    data["login"] = "true";
                    data["username"] = username;
                    data["password"] = password;

                    var response = wb.UploadValues("https://www.samuelgosden.co.uk/api.php", "POST", data);
                    string responseInString = Encoding.UTF8.GetString(response);
                    Console.WriteLine(responseInString);
                    if (responseInString.Length == 64)
                    {
                        token = responseInString;
                        CurrentUser = username;
                        lblDescription.Text = "Logged is as: " + CurrentUser;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "The remote server returned an error: (401) Unauthorized.")
                {
                    MessageBox.Show("Invalid credentials.");
                }
            }
        }
    }
}
