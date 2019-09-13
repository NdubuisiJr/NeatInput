﻿using NeatInput.Domain.Hooking;
using NeatInput.Domain.Hooking.Mouse;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;

using System.Collections.Generic;

namespace NeatInput.Hooking.Mouse
{
    internal class MouseInputProcessorPipeline
    {
        private readonly List<IMouseInputProcessor> _processors;

        public MouseInputProcessorPipeline()
        {
            _processors = new List<IMouseInputProcessor>
            {
                new MouseKeyProcessor(),
                new MouseStateProcessor()
            };
        }

        public MouseInput Process(
            WindowsMessages msg, 
            MSLLHOOKSTRUCT msllhookstruct)
        {
            var input = new MouseInput
            {
                X = msllhookstruct.pt.X,
                Y = msllhookstruct.pt.Y
            };

            foreach (var processor in _processors)
            {
                processor.Process(
                    ref input, 
                    msg, 
                    msllhookstruct);
            }

            return input;
        }
    }
}
