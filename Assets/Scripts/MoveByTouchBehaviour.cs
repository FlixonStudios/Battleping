using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouchBehaviour : MonoBehaviour
{

    [SerializeField] float baseMoveSpeed = 100.0f;
    [SerializeField] float baseMaxHorizontalMoveSpeed = 5f;
    [SerializeField] float baseMaxVerticalMoveSpeed = 5f;
    [SerializeField] float baseMaxBrakeSpeed = 200.0f;
    [SerializeField] Joystick joystick;

    private float currentMoveSpeed;
    private Rigidbody2D myBody;

    private GameObject mathControllerObject;
    private MathController mathController;

    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        currentMoveSpeed = baseMoveSpeed;
        mathControllerObject = FindObjectOfType<MathControllerBehaviour>();
        
    
    }

    private void Update()
    {
        MovePlayerHorizontally();
        MovePlayerVertically();
        ThrottlePlayerVelocity();
        DecelerateToRest();
    }

    public void MovePlayerHorizontally()
    {
        float playerXInput = joystick.Horizontal * currentMoveSpeed;        
        myBody.AddForce(new Vector2(playerXInput,0), ForceMode2D.Force);
        
    }
    public void MovePlayerVertically()
    {
        float playerYInput = joystick.Vertical * currentMoveSpeed;
        myBody.AddForce(new Vector2(0, playerYInput), ForceMode2D.Force);
    }
    public void ThrottlePlayerVelocity()
    {
        float xVelocityMax = Mathf.Clamp(myBody.velocity.x, -baseMaxHorizontalMoveSpeed, baseMaxHorizontalMoveSpeed);
        float yVelocityMax = Mathf.Clamp(myBody.velocity.y, -baseMaxVerticalMoveSpeed, baseMaxVerticalMoveSpeed);

        myBody.velocity = new Vector2(xVelocityMax, yVelocityMax);        
    }
    public void DecelerateToRest()
    {
        float inverseHorizontalAmplitude = (1 - Mathf.Abs(joystick.Horizontal));
        float inverseVerticalAmplitude = (1 - Mathf.Abs(joystick.Vertical));
                
        float HorizontalVelocity = -myBody.velocity.x;
        float VerticalVelocity = -myBody.velocity.y;

        float xDecelerationToDefault = mathController.DiminishingExponentialFunction(inverseHorizontalAmplitude) *
                                        mathController.DefaultDecelerationToUse(HorizontalVelocity, baseMaxBrakeSpeed);
        
        float yDecelerationToDefault = mathController.DiminishingExponentialFunction(inverseVerticalAmplitude) *
                                        mathController.DefaultDecelerationToUse(VerticalVelocity, baseMaxBrakeSpeed);

        Vector2 decelerationToDefaultForce = new Vector2 (xDecelerationToDefault, yDecelerationToDefault);

        myBody.AddForce(decelerationToDefaultForce, ForceMode2D.Force);
              
    }

}
