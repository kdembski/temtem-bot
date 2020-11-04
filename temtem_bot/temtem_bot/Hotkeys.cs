using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace temtem_bot
{
    class Hotkeys
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private readonly IntPtr _hwnd;

        public Hotkeys(IntPtr hwnd)
        {
            this._hwnd = hwnd;
        }
        /// <summary>
        /// register all hotkeys
        /// </summary>
        public void RegisterAllHotkeys()
        {
            RegisterHotKey(_hwnd, 1, 0, (int)Keys.F10);
            RegisterHotKey(_hwnd, 2, 0, (int)Keys.F11);
            RegisterHotKey(_hwnd, 3, 0, (int)Keys.F9);
        }
        /// <summary>
        /// unregister all hotkeys
        /// </summary>
        public void UnregisterAllHotkeys()
        {
            UnregisterHotKey(_hwnd, 1);
            UnregisterHotKey(_hwnd, 2);
            UnregisterHotKey(_hwnd, 3);
        }
        /// <summary>
        /// Typical hotkey assigngments (fsMod)
        /// </summary>
        public enum WindowKeys
        {
            Alt = 0x0001,
            Control = 0x0002,
            Shift = 0x0004,
            Window = 0x0008,
        }
    }
}
