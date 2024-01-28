using TrollsVsElves.Core.Abstractions;
using System.Collections.Generic;
using System.Collections;

namespace TrollsVsElves.Scripts;

public class KeyBindingCollectionFlyweightContainer : ISingleton, IEnumerable<KeyValuePair<KeyInvocation, KeyBindingCollection>>
{
    private Dictionary<KeyInvocation, KeyBindingCollection> _keyBindingsByInvocation;

    public KeyBindingCollectionFlyweightContainer()
    {
        _keyBindingsByInvocation = new Dictionary<KeyInvocation, KeyBindingCollection>();
    }

    public KeyBindingCollection GetKeyBindingCollection(KeyInvocation keyInvocation)
    {
        if (_keyBindingsByInvocation.ContainsKey(keyInvocation))
        {
            return _keyBindingsByInvocation[keyInvocation];
        }

        _keyBindingsByInvocation[keyInvocation] = new KeyBindingCollection();
        return _keyBindingsByInvocation[keyInvocation];
    }



    public IEnumerator<KeyValuePair<KeyInvocation, KeyBindingCollection>> GetEnumerator()
    {
        return _keyBindingsByInvocation.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
