using System;
using System.Runtime.InteropServices;
using System.Threading;
using static TP.SafeNativeMethods;

namespace TP
{
    static class Program
    {
        static void Main()
        {
            var accent = new AccentPolicy()
            {
                AccentState = 3,
                AccentFlags = 0x100,
            };

            var accentPtr = Marshal.AllocHGlobal(Marshal.SizeOf(accent));
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData()
            {
                Attribute = 19,
                SizeOfData = Marshal.SizeOf(accent),
                Data = accentPtr
            };

            IntPtr hwnd = FindWindowW("Shell_TrayWnd", null);
            while (true)
            {
                SetWindowCompositionAttribute(hwnd, ref data);
                Thread.Sleep(125);
            }

            //Marshal.FreeHGlobal(accentPtr);
        }
    }
}
