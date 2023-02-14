using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControllerClickEvent
{
    Interact,
    Sprint,
    Confirm,
    Back,
    Jump,
    Aim,
    Shoot
}

/// <summary>
/// Input Handler centralize the button presses and remove from other scripts the necessity to know the button - action map.
/// Other scripts only need to know which action they want to be executed (defined on the <see cref="ControllerClickEvent"/>)
/// </summary>
public static class InputHandler
{
    /// <summary>
    /// Controller left axis
    /// </summary>
    static string LYAxis = "Vertical";
    static string LXAxis = "Horizontal";

    /// <summary>
    /// Controller right axis
    /// </summary>
    static string RXAxis = "Right Horizontal Directional";
    static string RYAxis = "Right Vertical Directional";

    /// <summary>
    /// Xbox Controller button map
    /// </summary>
    static string A = "joystick button 0";
    static string B = "joystick button 1";
    static string X = "joystick button 2";
    static string Y = "joystick button 3";
    //static string LB = "joystick button 4";
    //static string RB = "joystick button 5";
    static string RT = "RT";
    static string LT = "LT";

    static readonly Dictionary<ControllerClickEvent, string> controllerButtonMap =
    new Dictionary<ControllerClickEvent, string>
    {
            { ControllerClickEvent.Interact, Y },
            { ControllerClickEvent.Sprint, X },
            { ControllerClickEvent.Confirm, A },
            { ControllerClickEvent.Back, B },
            { ControllerClickEvent.Jump, A },
            { ControllerClickEvent.Aim, LT },
            { ControllerClickEvent.Shoot, RT },
    };

    /// <summary>
    /// Get the Input value for the player action specified. Uses a dictionary to map action to button
    /// </summary>
    /// <param name="">Player action</param>
    /// <returns>The value for the current player action button press</returns>
    public static bool ButtonPress(ControllerClickEvent playerAction)
    {
        string buttonPress = controllerButtonMap[playerAction];
        return Input.GetKeyDown(buttonPress);
    }

    /// <summary>
    /// Gets the left directional axis values of the controller
    /// </summary>
    /// <returns>Vector with (float X, flota Y) axis coordinates </returns>
    public static Vector2 LeftDirectional()
    {
        return new Vector2(Input.GetAxis(LXAxis), Input.GetAxis(LYAxis));
    }

    /// <summary>
    /// Gets the keyboard arrows input values as Vector2
    /// </summary>
    /// <returns>Vector with x and y values from keyboard arrow inputs. </returns>
    public static Vector2 GetArrowInput()
    {
        float y = Convert.ToSingle(Input.GetKey(KeyCode.UpArrow)) - Convert.ToSingle(Input.GetKey(KeyCode.DownArrow));
        float x = Convert.ToSingle(Input.GetKey(KeyCode.RightArrow)) - Convert.ToSingle(Input.GetKey(KeyCode.LeftArrow));

        return new Vector2(x, y);
    }

    /// <summary>
    /// Gets the right directional axis values of the controller
    /// </summary>
    /// <returns>Vector with (float X, flota Y) axis coordinates </returns>
    public static Vector2 RightDirectional()
    {
        return new Vector2(Input.GetAxis(RXAxis), Input.GetAxis(RYAxis));
    }
}
