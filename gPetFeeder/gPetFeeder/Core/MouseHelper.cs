using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace gPetFeeder.Core
{
    public class MouseHelper
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(UInt32 dwFlags, UInt32 dx, int UInt32, UInt32 dwData, UIntPtr dwExtraInfo);

        // constants for the mouse_input() API function
        private const UInt32 MOUSEEVENTF_MOVE = 0x0001;
        private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;
        private const UInt32 MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const UInt32 MOUSEEVENTF_RIGHTUP = 0x0010;
        private const UInt32 MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const UInt32 MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const UInt32 MOUSEEVENTF_ABSOLUTE = 0x8000;

        public static void MouseMove(Int32 x, Int32 y)
        {
            Cursor.Position = new System.Drawing.Point(x, y);
        }

        public static void MouseLeftClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
        }
    }
}
