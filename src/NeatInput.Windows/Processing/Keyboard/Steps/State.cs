﻿using NeatInput.Windows.Processing.Keyboard.Enums;
using NeatInput.Windows.Win32.Enums;

using Paipurain.Application.Handler;

using System.Linq;
using System.Collections.Generic;

namespace NeatInput.Windows.Processing.Keyboard.Steps
{
    internal class State : IHandler<ValueWrapper>
    {
        private readonly Dictionary<KeyStates, List<WindowsMessages>> _stateMessagesMap;

        internal State()
        {
            _stateMessagesMap = new Dictionary<KeyStates, List<WindowsMessages>>();

            RegisterDownStateMessages();
            RegisterUpStateMessages();
        }

        public ValueWrapper Handle(ValueWrapper item)
        {
            item.Output.State = GetState(item.Message);

            System.Console.WriteLine(item.Output.Key + " | " + item.Output.State);

            return item;
        }

        private KeyStates GetState(WindowsMessages msg)
        {
            return _stateMessagesMap
                .FirstOrDefault(kvp => kvp.Value.Contains(msg))
                .Key;
        }

        private void RegisterDownStateMessages()
        {
            var messages = new List<WindowsMessages>
            {
               WindowsMessages.KEYDOWN,
               WindowsMessages.SYSKEYDOWN
            };

            _stateMessagesMap.Add(KeyStates.Down, messages);
        }

        private void RegisterUpStateMessages()
        {
            var messages = new List<WindowsMessages>
            {
               WindowsMessages.KEYUP,
               WindowsMessages.SYSKEYUP
            };

            _stateMessagesMap.Add(KeyStates.Up, messages);
        }
    }
}
