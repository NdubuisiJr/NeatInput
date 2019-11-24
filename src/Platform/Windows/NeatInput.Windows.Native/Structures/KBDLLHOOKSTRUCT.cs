﻿using NeatInput.Windows.Native.Enumerations.Flags;

using System;
using System.Runtime.InteropServices;

namespace NeatInput.Windows.Native.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct KBDLLHOOKSTRUCT
    {
        public uint vkCode;
        public uint scanCode;
        public KBDLLHOOKSTRUCTFlags flags;
        public uint time;
        public UIntPtr dwExtraInfo;
    }
}
