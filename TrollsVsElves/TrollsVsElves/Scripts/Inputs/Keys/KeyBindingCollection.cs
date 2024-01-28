using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;
using TrollsVsElves.Core.Abstractions;
using TrollsVsElves.Scripts.Services;

namespace TrollsVsElves.Scripts;

public class KeyBindingCollection : ITransient, IEnumerable<KeyValuePair<KeyCode, ICommand>>
{
    private Dictionary<KeyCode, ICommand> _commandByKeyCode;

    public KeyBindingCollection()
    {
        _commandByKeyCode = new Dictionary<KeyCode, ICommand>();
    }

    public KeyBindingCollection AddKeyBinding(KeyCode key, ICommand command)
    {
        _commandByKeyCode[key] = command;
        return this;
    }

    public IEnumerator<KeyValuePair<KeyCode, ICommand>> GetEnumerator()
    {
        return _commandByKeyCode.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
