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
        float inputValueAbsolute = Mathf.Abs(zeroToOneInput);
        float inputValueSign = Mathf.Sign(zeroToOneInput);

        if (inputValueAbsolute > 1)
        {
            return 1 * inputValueSign;
        }        
        if (inputValueAbsolute <= Mathf.Epsilon)
        {
            return 0;
        }
        else
        {
            return Mathf.Clamp(inputValueSign * Mathf.Pow(zeroToOneInput, 4), -1, 1);
        }
    }
    public float DefaultDecelerationToUse(float inputVelocity, float moveSpeed)
    {

        float opposingForce = Mathf.Pow(inputVelocity, 2);

        return opposingForce * Mathf.Sign(inputVelocity);
    }
}
