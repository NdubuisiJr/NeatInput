﻿using NeatInput.Application.Processing.Mouse;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing.Keyboard;
using NeatInput.Domain.Processing.Mouse;

namespace NeatInput.Processing.Mouse
{
    internal class WheelProcessor :
        IMouseInputProcessor
    {
        public void Process(
            ref MouseInput input, 
            WindowsMessages windowsMessage,
            MSLLHOOKSTRUCT hookStruct)
        {
            if (input.Key != VirtualKeyCodes.SCROLL)
                return;

            if (ProcessorHelpers.HIWORD(hookStruct.mouseData) > 0)
                input.State = MouseState.KeyUp;
            else
                input.State = MouseState.KeyDown;
        }
    }
}
