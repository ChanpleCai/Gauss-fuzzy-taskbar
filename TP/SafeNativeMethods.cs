using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    [SuppressUnmanagedCodeSecurity]
    static class SafeNativeMethods
    {
        [DllImport("user32.dll")]
        internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        [StructLayout(LayoutKind.Sequential)]
        internal struct AccentPolicy
        {
            public int AccentState;
            public int AccentFlags;
            public int GradientColor;
            public int AnimationId;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct WindowCompositionAttributeData
        {
            public int Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        [DllImport("user32.dll", EntryPoint = "FindWindowW")]
        public static extern IntPtr FindWindowW([In()] [MarshalAs(UnmanagedType.LPWStr)] string lpClassName, [In()] [MarshalAs(UnmanagedType.LPWStr)] string lpWindowName);

    }
}
