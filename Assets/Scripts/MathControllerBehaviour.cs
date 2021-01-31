using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathControllerBehaviour : MonoBehaviour
{
    public MathController mathController;
    public float Speed;

    private void Start()
    {
        mathController = new MathController();
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
