using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace temtem_bot
{
    class InputSimulations: Screen
    {
            [DllImport("user32.dll", SetLastError = true)]
            static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
            [DllImport("user32.dll", SetLastError = true)]
            static extern void SetCursorPos(int x, int y);
            [DllImport("user32.dll")]
            public static extern bool GetCursorPos(out Point p);
            [DllImport("user32.dll", SetLastError = true)]
            static extern void mouse_event(int dwflags, int dx, int dy, int cButtons, int dwExtraInfo);
            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            private static extern short GetKeyState(int keyCode);

            private const int MOUSEEVENTF_LEFTDOWN = 0x02;
            private const int MOUSEEVENTF_LEFTUP = 0x04;

            [Flags]
            private enum KeyStates
            {
                None = 0,
                Down = 1,
                Toggled = 2
            }

            /// <summary>
            /// simulates key hold
            /// </summary>
            /// <param name="key">which key is pressed</param>
            /// <param name="minDuration">min duration of hold</param>
            /// <param name="maxDuration">max duration of hold</param>
            /// <param name="sleepAfterPressMin">min sleep after press</param>
            /// <param name="sleepAfterPressMax">max sleep after press</param>
            protected static void HoldKey(byte key, int minDuration, int maxDuration, int sleepAfterPressMin, int sleepAfterPressMax)
            {
                Random sleepAfterPress = new Random();
                Random sleepHoldDuration = new Random();

                KeyDown(key);
                Thread.Sleep(sleepHoldDuration.Next(minDuration, maxDuration));
                KeyUp(key);
                Thread.Sleep(sleepAfterPress.Next(sleepAfterPressMin, sleepAfterPressMax));
            }
            /// <summary>
            /// press selected key down
            /// </summary>
            /// <param name="key"></param>
            protected static void KeyDown(byte key)
            {
                int KEY_DOWN_EVENT = 0x0001;
                keybd_event(key, 0, KEY_DOWN_EVENT, 0);
            }
            /// <summary>
            /// press selected key up
            /// </summary>
            /// <param name="key"></param>
            public static void KeyUp(byte key)
            {
                int KEY_UP_EVENT = 0x0002;
                keybd_event(key, 0, KEY_UP_EVENT, 0);
            }
            /// <summary>
            /// check and return key state
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            private static KeyStates GetKeyState(Keys key)
            {
                KeyStates state = KeyStates.None;

                short retVal = GetKeyState((int)key);

                //If the high-order bit is 1, the key is down
                //otherwise, it is up.
                if ((retVal & 0x8000) == 0x8000)
                    state |= KeyStates.Down;

                //If the low-order bit is 1, the key is toggled.
                if ((retVal & 1) == 1)
                    state |= KeyStates.Toggled;

                return state;
            }
            /// <summary>
            /// check if key is down
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public static bool IsKeyDown(Keys key)
            {
                return KeyStates.Down == (GetKeyState(key) & KeyStates.Down);
            }
            /// <summary>
            /// check if key is toggled
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            protected static bool IsKeyToggled(Keys key)
            {
                return KeyStates.Toggled == (GetKeyState(key) & KeyStates.Toggled);
            }
            /// <summary>
            /// simulates mouse click
            /// </summary>
            /// <param name="x">x coordinates of click</param>
            /// <param name="y">y coordinates of click</param>
            protected static void MouseLeftClick(int x, int y, int xError, int yError)
            {
            Point destination = new Point(new Random().Next(x - xError, x + xError), new Random().Next(y - yError, y + yError));

                LinearSmoothMove(destination);
                mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
                Thread.Sleep((new Random()).Next(10, 25));
                mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                Thread.Sleep(new Random().Next(255, 455));

            }
            /// <summary>
            /// smoothly move mouse to indicated position
            /// </summary>
            /// <param name="newPosition"></param>
            public static void LinearSmoothMove(Point newPosition)
            {
                GetCursorPos(out Point start);
                PointF iterPoint = start;
                int steps = new Random().Next(33, 44);

                // Find the slope of the line segment defined by start and newPosition
                PointF slope = new PointF(newPosition.X - start.X, newPosition.Y - start.Y);

                // Divide by the number of steps
                slope.X = slope.X / steps;
                slope.Y = slope.Y / steps;

                // Move the mouse to each iterative point.
                for (int i = 0; i < steps; i++)
                {
                    iterPoint = new PointF(iterPoint.X + slope.X, iterPoint.Y + slope.Y);
                    SetCursorPos(Point.Round(iterPoint).X, Point.Round(iterPoint).Y);
                    Thread.Sleep(new Random().Next(1, 3));
                }

                // Move the mouse to the final destination.
                SetCursorPos(newPosition.X, newPosition.Y);
            }
        }
}
