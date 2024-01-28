using TrollsVsElves.Core.Abstractions;
using TrollsVsElves.Scripts.Services;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;

namespace TrollsVsElves.Scripts;

public class InputHandlerComponent : Component, ISingleton, IUpdateableComponent
{
    private KeyBindingCollectionFlyweightContainer _keyBindingsByInvocationCollection;

    public InputHandlerComponent(KeyBindingCollectionFlyweightContainer keyBindingsByInvocationCollection)
    {
        _keyBindingsByInvocationCollection = keyBindingsByInvocationCollection;
    }

    public InputHandlerComponent AddKeyBinding(KeyCode keyCode, ICommand command, KeyInvocation keyInvocation)
    {
        var keyBindings = _keyBindingsByInvocationCollection.GetKeyBindingCollection(keyInvocation);
        keyBindings.AddKeyBinding(keyCode, command);
        return this;
    }


    public void Update(float deltaTime)
    {
        foreach (var keyBindingsByInvocation in _keyBindingsByInvocationCollection)
        {
            var keyInvocation = keyBindingsByInvocation.Key;
            var keybindings = keyBindingsByInvocation.Value;

            InvokeKeyBindingsWithKeyInvocation(keyInvocation, keybindings);
        }


        static void InvokeKeyBindingsWithKeyInvocation(KeyInvocation keyInvocation, KeyBindingCollection keyBindings)
        {
            switch (keyInvocation)
            {
                case KeyInvocation.GetKey:
                    InvokeKeyBindingCollection(keyBindings, Input.GetKey);
                    break;

                case KeyInvocation.GetKeyUp:
                    InvokeKeyBindingCollection(keyBindings, Input.GetKeyUp);
                    break;

                case KeyInvocation.GetKeyDown:
                    InvokeKeyBindingCollection(keyBindings, Input.GetKeyUp);
                    break;

                default: throw new Exception("KeyInvocation handling not implemented");
            }

            static void InvokeKeyBindingCollection(KeyBindingCollection keyBindings, Func<KeyCode, bool> predication)
            {
                foreach (var keyBinding in keyBindings)
                {
                    var keyCode = keyBinding.Key;

                    if (predication(keyCode))
                    {
                        var command = keyBinding.Value;
                        command.Excecute();
                    }
                }
            }
        }
    }




}
