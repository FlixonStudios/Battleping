using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    float GetDeltaTime();
    float GetJoystickInputHorizontalRaw(Joystick joystick);
    float GetJoystickInputVerticalRaw(Joystick joystick);
}
public class MovementService : IMovement
{
    public float GetDeltaTime()
    {
        return Time.deltaTime;
    }
    public float GetJoystickInputHorizontalRaw(Joystick joystick)
    {
        return joystick.Horizontal;        
    }
    public float GetJoystickInputVerticalRaw(Joystick joystick)
    {
        return joystick.Vertical;
    }
}
