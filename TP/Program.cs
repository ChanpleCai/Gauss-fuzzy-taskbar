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
                AccentState = 2,
                AccentFlags = 2,
                GradientColor = 0
            };

            var accentPtr = Marshal.AllocHGlobal(Marshal.SizeOf(accent));
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData()
            {
                Attribute = 19,
                SizeOfData = Marshal.SizeOf(accent),
                Data = accentPtr
            };

            while (true)
            {
                SetWindowCompositionAttribute(FindWindowW("Shell_TrayWnd", null), ref data);
                Thread.Sleep(10);
            }

            //Marshal.FreeHGlobal(accentPtr);
        }
    }
}
