using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace AutoFCO
{
    public partial class formBan : Form
    {
        // Constants for window resizing
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_SHOWWINDOW = 0x0040;

        // Import necessary APIs
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern void SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

        private const int SW_RESTORE = 9; // Command to restore the window if minimized

        // Input structures
        [StructLayout(LayoutKind.Sequential)]
        private struct INPUT
        {
            public int type; // 0 = INPUT_MOUSE
            public MOUSEINPUT mi;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        private const uint MOUSEEVENTF_MOVE = 0x0001;
        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;

        public formBan()
        {
            InitializeComponent();
        }

        public void ResizeGameWindow()
        {
            try
            {
                IntPtr gameWindow = FindWindow(null, "FC Online"); // Replace with your game's window name
                if (gameWindow == IntPtr.Zero)
                {
                    MessageBox.Show("Game window not found!");
                    return;
                }

                // Restore the window if minimized
                ShowWindow(gameWindow, SW_RESTORE);

                // Resize the window to 1280x720
                bool result = SetWindowPos(gameWindow, IntPtr.Zero, 0, 0, 1280, 720, SWP_NOZORDER | SWP_SHOWWINDOW);
                if (!result)
                {
                    MessageBox.Show("Failed to resize game window!");
                }
                else
                {
                    MessageBox.Show("Game window resized to 1280x720!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public void SimulateMouseClicks(int x, int y, int clickCount = 1)
        {
            try
            {
                for (int i = 0; i < clickCount; i++)
                {
                    // Create mouse down input
                    INPUT mouseDown = new INPUT
                    {
                        type = 0, // Mouse input
                        mi = new MOUSEINPUT
                        {
                            dx = x * (65536 / Screen.PrimaryScreen.Bounds.Width), // Normalize to 0-65535
                            dy = y * (65536 / Screen.PrimaryScreen.Bounds.Height),
                            dwFlags = MOUSEEVENTF_MOVE | MOUSEEVENTF_LEFTDOWN,
                            time = 0,
                            dwExtraInfo = IntPtr.Zero
                        }
                    };

                    // Create mouse up input
                    INPUT mouseUp = new INPUT
                    {
                        type = 0, // Mouse input
                        mi = new MOUSEINPUT
                        {
                            dx = x * (65536 / Screen.PrimaryScreen.Bounds.Width), // Normalize to 0-65535
                            dy = y * (65536 / Screen.PrimaryScreen.Bounds.Height),
                            dwFlags = MOUSEEVENTF_MOVE | MOUSEEVENTF_LEFTUP,
                            time = 0,
                            dwExtraInfo = IntPtr.Zero
                        }
                    };

                    // Send mouse down and up inputs
                    SendInput(1, new INPUT[] { mouseDown }, Marshal.SizeOf(typeof(INPUT)));
                    SendInput(1, new INPUT[] { mouseUp }, Marshal.SizeOf(typeof(INPUT)));

                    Thread.Sleep(100); // Pause briefly between clicks
                }

                MessageBox.Show($"Simulated {clickCount} mouse clicks at ({x}, {y}).");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
