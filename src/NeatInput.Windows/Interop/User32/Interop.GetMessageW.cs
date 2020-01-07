﻿using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class User32
    {
        [DllImport(Libraries.User32, ExactSpelling = true)]
        internal static extern bool GetMessageW(
            ref MSG message,
            IntPtr hWnd,
            uint wMsgFilterMin,
            uint wMsgFilterMax);
    }
}