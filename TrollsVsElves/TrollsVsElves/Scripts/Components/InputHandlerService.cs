using Microsoft.Xna.Framework.Input;
using TrollsVsElves.Core.Lifetime;

namespace TrollsVsElves.Scripts.Services
{
    public class InputHandlerService : ISingleton
    {
        public KeyboardState KeyboardState { get; set; }
        public MouseState MouseState { get; set; }
    }
}