using System.Diagnostics;
using TrollsVsElves.Core.Services;
using TrollsVsElves.Scripts.Services;

namespace TrollsVsElves.Scripts;

public class InputHandlerExample
{
    private GameObjectCollection _gameObjectCollection;

    public InputHandlerExample(GameObjectCollection gameObjectCollection)
    {
        _gameObjectCollection = gameObjectCollection;
    }

    public void Setup()
    {
        var singletonContainer = _gameObjectCollection.GetGameObjectWithName("SingletonContainer");
        var inputHandler = singletonContainer.GetComponent<InputHandlerComponent>();

        inputHandler.AddKeyBinding(KeyCode.J, new DebugCommand(), KeyInvocation.GetKeyDown);
    }

    private class DebugCommand : ICommand
    {
        public void Excecute()
        {
            Debug.WriteLine("Here");
        }
    }
}
