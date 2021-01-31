using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerForceControl
{

    public float BaseThrust;

    public PlayerForceControl(float baseThrust)
    {
        BaseThrust = baseThrust;
    }

    public Vector2 CalculateForce(float horizontalInput, float verticalInput, float deltaTime)
    {
        var horizontalForce = horizontalInput * BaseThrust * deltaTime;
        var verticalForce = verticalInput * BaseThrust * deltaTime;

        return new Vector2(horizontalForce, verticalForce);
    }
    
}
