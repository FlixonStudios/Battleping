using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathControllerBehaviour : MonoBehaviour
{
    public MathController mathController;


    public float Speed;
    private void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        var deltaTime = Time.deltaTime;

        transform.position += CalculateMovement(h, v, deltaTime);
    }

    private Vector3 CalculateMovement(float h, float v, float deltaTime)
    {
        var x = h * Speed * deltaTime;
        var z = v * Speed * deltaTime;

        return new Vector3(x, 0, z);
    }
}
public class MathController
{
    public float DiminishingExponentialFunction(float zeroToOneInput)
    {
        if (zeroToOneInput <= Mathf.Epsilon)
        {
            return 0;
        }
        else
        {
            return Mathf.Clamp(1 / zeroToOneInput, 0, 1);
        }
    }
    public float DefaultDecelerationToUse(float inputVelocity, float moveSpeed)
    {

        float opposingForce = Mathf.Pow(inputVelocity, 2);

        return opposingForce * Mathf.Sign(inputVelocity);
    }
}
