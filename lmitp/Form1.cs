
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security.Authentication;

namespace AutoFCO
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            buttonBan.Enabled = false;
            buttonLogin.Enabled = false;
            buttonMua.Enabled = false;

            var loginForm = new formLogin();
            loginForm.LoginSuccess += OnLoginSuccess; // Subscribe to the login success event
            loadform(loginForm);
        }

        private void OnLoginSuccess(object sender, EventArgs e)
        {
            // Enable the buttons after successful login
            buttonBan.Enabled = true;
            buttonMua.Enabled = true;

            MessageBox.Show("Login successful!");

            // Registering F5 as a global hotkey
            RegisterHotKey(this.Handle, HOTKEY_ID, MOD_NONE, VK_F5);

        }

        // Importing necessary functions from user32.dll
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private const int HOTKEY_ID = 1;
        private const uint MOD_NONE = 0x0000; // No modifier key
        private const uint VK_F5 = 0x74; // Virtual-key code for F5

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HOTKEY_ID)
            {
                LaunchGame();
            }
            base.WndProc(ref m);
        }

        private void LaunchGame()
        {
            try
            {
                // Step 1: Find the Garena executable on all drives
                string garenaPath = FindGarenaPath();

                if (string.IsNullOrEmpty(garenaPath))
                {
                    MessageBox.Show("Garena not found on any drive!");
                    return;
                }

                // Step 2: Launch Garena
                Process.Start(garenaPath);

                // Step 3: Wait for Garena to open
                System.Threading.Thread.Sleep(5000); // Adjust as necessary

                // Step 4: Bring Garena window to the foreground
                IntPtr garenaHandle = FindWindow(null, "Garena - Your Ultimate Game Platform");
                if (garenaHandle != IntPtr.Zero)
                {
                    SetForegroundWindow(garenaHandle);

                    // Simulate keyboard or mouse input to open the game
                    SendKeys.SendWait("{ENTER}"); // Example: Simulate ENTER
                }
                else
                {
                    MessageBox.Show("Garena window not found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private string FindGarenaPath()
        {
            // Get all drives on the system
            var drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                // Check if the drive is ready and accessible
                if (drive.IsReady)
                {
                    string potentialPath = Path.Combine(drive.RootDirectory.FullName, @"Program Files (x86)\Garena\Garena\Garena.exe");
                    if (File.Exists(potentialPath))
                    {
                        return potentialPath; // Return the path if Garena is found
                    }
                }
            }

            return null; // Return null if Garena is not found on any drive
        }


        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }

        private void btndashbaord_Click(object sender, EventArgs e)
        {
            loadform(new formLogin());
        }

        private void btnemp_Click(object sender, EventArgs e)
        {
            loadform(new formMua());
        }

        private void btnreports_Click(object sender, EventArgs e)
        {
            loadform(new formBan());
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Unregister the hotkey
            UnregisterHotKey(this.Handle, HOTKEY_ID);
            base.OnFormClosing(e);
        }
    }
}
