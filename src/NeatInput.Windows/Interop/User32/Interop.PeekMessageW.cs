﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file for more information:
//      https://github.com/dotnet/winforms/blob/master/LICENSE.TXT

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class User32
    {
        [DllImport(Libraries.User32, ExactSpelling = true)]
        internal static extern bool PeekMessageW(
            ref MSG msg,
            IntPtr hwnd = default,
            WindowMessage msgMin = 0,
            WindowMessage msgMax = 0,
            PM remove = PM.NOREMOVE);
    }
}
