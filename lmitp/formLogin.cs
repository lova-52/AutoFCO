using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFCO
{
    public partial class formLogin : Form
    {
        private readonly FirebaseClient firebaseClient;

        // Define an event to signal login success
        public event EventHandler LoginSuccess;

        public formLogin()
        {
            InitializeComponent();
            firebaseClient = new FirebaseClient("https://autofc-212ff-default-rtdb.asia-southeast1.firebasedatabase.app/"); // Replace with your Firebase URL

        }


        public bool AuthenticateUser(string key)
        {
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Replace this with your actual login logic
            bool loginSuccessful = AuthenticateUser(textBox1.Text.ToString());

            if (loginSuccessful)
            {
                // Trigger the LoginSuccess event
                LoginSuccess?.Invoke(this, EventArgs.Empty);

                // Optionally, close the login form
                this.Close();
            }
            else
            {
                MessageBox.Show("Login failed. Please try again.");
            }

            this.Close();
        }
    }
}
