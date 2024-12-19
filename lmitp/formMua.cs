using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace AutoFCO
{
    public partial class formMua : Form
    {
        public formMua()
        {
            InitializeComponent();
        }

        // Importing necessary functions from user32.dll and gdi32.dll
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll")]
        private static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSrc, int xSrc, int ySrc, int rop);

        private const int SRCCOPY = 0x00CC0020; // Raster-operation code for BitBlt

        // Constants for mouse input
        private const uint WM_LBUTTONDOWN = 0x0201;
        private const uint WM_LBUTTONUP = 0x0202;

        /// <summary>
        /// Tính toán giá trị lParam từ tọa độ x, y.
        /// </summary>
        private IntPtr MakeLParam(int x, int y)
        {
            return (IntPtr)((y << 16) | (x & 0xFFFF));
        }

        /// <summary>
        /// Resizes the "FC Online" window to 1280x720.
        /// </summary>
        private void ResizeGameWindow()
        {
            IntPtr windowHandle = FindWindow(null, "FC Online");
            if (windowHandle == IntPtr.Zero)
            {
                MessageBox.Show("Game window not found!");
                return;
            }

            bool result = MoveWindow(windowHandle, 0, 0, 1280, 720, true);
            if (!result)
            {
                MessageBox.Show("Failed to resize the window!");
            }
        }

        /// <summary>
        /// Grabs the color of a pixel in the specified window.
        /// </summary>
        private Color? GetPixelColor(string windowName, int x, int y)
        {
            IntPtr windowHandle = FindWindow(null, windowName);
            if (windowHandle == IntPtr.Zero)
            {
                return null;
            }

            IntPtr hdc = GetWindowDC(windowHandle);
            if (hdc == IntPtr.Zero)
            {
                return null;
            }

            uint pixel = GetPixel(hdc, x, y);
            ReleaseDC(windowHandle, hdc);

            int r = (int)(pixel & 0x000000FF);
            int g = (int)((pixel & 0x0000FF00) >> 8);
            int b = (int)((pixel & 0x00FF0000) >> 16);

            return Color.FromArgb(r, g, b);
        }

        /// <summary>
        /// Compares a pixel color with a given color.
        /// </summary>
        private bool ComparePixelWithColor(string windowName, int x, int y, Color? colorToCompare)
        {
            Color? pixelColor = GetPixelColor(windowName, x, y);
            return pixelColor != null && pixelColor.Value.Equals(colorToCompare);
        }

        /// <summary>
        /// Simulates mouse clicks on the specified window.
        /// </summary>
        private void SimulateMouseClick(string windowName, int x, int y, int interval, int numberOfClicks)
        {
            IntPtr windowHandle = FindWindow(null, windowName);
            if (windowHandle == IntPtr.Zero)
            {
                MessageBox.Show("Game window not found!");
                return;
            }

            for (int i = 0; i < numberOfClicks; i++)
            {
                // Gửi sự kiện chuột xuống
                PostMessage(windowHandle, WM_LBUTTONDOWN, IntPtr.Zero, MakeLParam(x, y));

                // Gửi sự kiện chuột lên
                PostMessage(windowHandle, WM_LBUTTONUP, IntPtr.Zero, MakeLParam(x, y));

                // Chờ giữa các lần click
                if (i < numberOfClicks - 1)
                {
                    Thread.Sleep(interval);
                }
            }
        }

        /// <summary>
        /// Chụp một diện tích của cửa sổ game và trả về hình ảnh.
        /// </summary>
        private Bitmap CaptureRegion(string windowName, int x, int y, int width, int height)
        {
            IntPtr windowHandle = FindWindow(null, windowName);
            if (windowHandle == IntPtr.Zero)
            {
                MessageBox.Show("Game window not found!");
                return null;
            }

            IntPtr hdcWindow = GetWindowDC(windowHandle);
            if (hdcWindow == IntPtr.Zero)
            {
                MessageBox.Show("Failed to get device context!");
                return null;
            }

            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                IntPtr hdcBitmap = g.GetHdc();
                BitBlt(hdcBitmap, 0, 0, width, height, hdcWindow, x, y, SRCCOPY);
                g.ReleaseHdc(hdcBitmap);
            }

            ReleaseDC(windowHandle, hdcWindow);
            return bitmap;
        }

        /// <summary>
        /// So sánh hai hình ảnh trong bộ nhớ.
        /// </summary>
        private bool CompareBitmaps(Bitmap bmp1, Bitmap bmp2)
        {
            if (bmp1.Width != bmp2.Width || bmp1.Height != bmp2.Height)
                return false;

            for (int x = 0; x < bmp1.Width; x++)
            {
                for (int y = 0; y < bmp1.Height; y++)
                {
                    if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                        return false;
                }
            }
            return true;
        }


        // Button click to test functionality
        private void button1_Click(object sender, EventArgs e)
        {
            // Resize the game window
            ResizeGameWindow();

            // Lấy màu pixel ban đầu
            Color? initialColor = GetPixelColor("FC Online", 855, 119);

            // Lặp lại việc click cho tới khi pixel thay đổi màu
            while (ComparePixelWithColor("FC Online", 855, 119, initialColor))
            {
                // Click vào vị trí trong game
                SimulateMouseClick("FC Online", 824, 642, 100, 1);
            }

            Bitmap initialRegion = CaptureRegion("FC Online", 955, 275, 200, 200);

            MessageBox.Show("wai");

            Bitmap futureRegion = CaptureRegion("FC Online", 955, 275, 200, 200);

            pictureBox1.Image = initialRegion;
            pictureBox2.Image = futureRegion;

            if (initialRegion != null && futureRegion != null && !CompareBitmaps(initialRegion, futureRegion))
            {
                MessageBox.Show("Region has changed!");
            }
            else
            {
                MessageBox.Show("Region stayed the same!");
            }

            initialRegion?.Dispose();
            futureRegion?.Dispose();
        }
    }
}
