using Microsoft.Xna.Framework.Input;
using System;

namespace TrollsVsElves.Scripts.Services;

public static class Input
{
    private static KeyboardState _keyState;
    private static KeyboardState _previousKeyState;

    private static MouseState _mouseState;
    private static MouseState _previousMouseState;


 
    public static bool GetKey(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.LeftMouse: return IsPressed(_mouseState.LeftButton);
            case KeyCode.RightMouse: return IsPressed(_mouseState.RightButton);
            case KeyCode.MiddleMouse: return IsPressed(_mouseState.MiddleButton);
            default:
                var key = ConvertKeyCodeToKeys(keyCode);
                return GetKey(key);
        }

        static bool IsPressed(ButtonState buttonState)
        {
            return buttonState == ButtonState.Pressed;
        }
    }

    public static bool GetKeyDown(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.LeftMouse:
                return IsButtonDown(_mouseState.LeftButton, _previousMouseState.LeftButton);
            case KeyCode.RightMouse:
                return IsButtonDown(_mouseState.RightButton, _previousMouseState.RightButton);
            case KeyCode.MiddleMouse:
                return IsButtonDown(_mouseState.MiddleButton, _previousMouseState.MiddleButton);

            default:
                var key = ConvertKeyCodeToKeys(keyCode);
                return GetKeyDown(key);
        }

        static bool IsButtonDown(ButtonState buttonState, ButtonState previousButtonState)
        {
            var wasItPressedLastUpdate = previousButtonState == ButtonState.Pressed;
            var isPressed = buttonState == ButtonState.Pressed;
            return isPressed && wasItPressedLastUpdate == false;
        }
    }


    public static bool GetKeyUp(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.LeftMouse:
                return IsButtonUp(_mouseState.LeftButton, _previousMouseState.LeftButton);
            case KeyCode.RightMouse:
                return IsButtonUp(_mouseState.RightButton, _previousMouseState.RightButton);
            case KeyCode.MiddleMouse:
                return IsButtonUp(_mouseState.MiddleButton, _previousMouseState.MiddleButton);
            default:
                var key = ConvertKeyCodeToKeys(keyCode);
                return GetKeyUp(key);
        }

        static bool IsButtonUp(ButtonState buttonState, ButtonState previousButtonState)
        {
            var wasItPressedLastUpdate = previousButtonState == ButtonState.Pressed;
            var isPressed = buttonState == ButtonState.Pressed;
            return isPressed == false && wasItPressedLastUpdate;
        }
    }

    public static void Update()
    {
        _previousKeyState = _keyState;
        _previousMouseState = _mouseState;
        _keyState = Keyboard.GetState();
        _mouseState = Mouse.GetState();
    }

    public static Vector2 GetMousePosition()
    {
        return new Vector2(_mouseState.X, _mouseState.Y);
    }

    private static bool GetKey(Keys key)
    {
        return _keyState.IsKeyDown(key);
    }

    private static bool GetKeyDown(Keys key)
    {
        var wasItPreviousKey = _previousKeyState.IsKeyDown(key);
        return _keyState.IsKeyDown(key) && wasItPreviousKey == false;
    }

    private static bool GetKeyUp(Keys key)
    {
        var wasItPreviousKey = _previousKeyState.IsKeyDown(key);
        return _keyState.IsKeyUp(key) && wasItPreviousKey;
    }

    private static Keys ConvertKeyCodeToKeys(KeyCode keyCode)
    {
        return (Keys)Enum.Parse(typeof(Keys), keyCode.ToString());
    }
}