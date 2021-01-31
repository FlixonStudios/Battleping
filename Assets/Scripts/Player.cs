using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float baseThrust = 100.0f;
    [SerializeField] float baseMaxHorizontalMoveSpeed = 5f;
    [SerializeField] float baseMaxVerticalMoveSpeed = 5f;
    [SerializeField] float baseMaxBrakeSpeed = 200.0f;
    [SerializeField] Joystick joystick;

    private float currentMoveSpeed;
    private Rigidbody2D myBody;

    private GameObject mathControllerObject;
    private MathController mathController;
    public PlayerForceControl playerForceControl;

    public IMovement MovementService;

    private void Start()
    {
        currentMoveSpeed = baseThrust;

        myBody = GetComponent<Rigidbody2D>();
        
        playerForceControl = new PlayerForceControl(baseThrust);
        
        mathController = FindObjectOfType<MathControllerBehaviour>().mathController;

        if (MovementService == null)
            MovementService = new MovementService();
    
    }

    private void Update()
    {
        MovePlayer();
        
        ThrottlePlayerVelocity();
        DecelerateToRest();
    }

    public void MovePlayer()
    {        
        AddForceToPlayer(playerForceControl
                        .CalculateForce(MovementService.GetJoystickInputHorizontalRaw(joystick),
                                        MovementService.GetJoystickInputVerticalRaw(joystick), 
                                        MovementService.GetDeltaTime())
                        );
        
    }
    
    private void AddForceToPlayer(Vector2 playerInput)
    {
        myBody.AddForce(playerInput, ForceMode2D.Force);
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

        AddForceToPlayer(decelerationToDefaultForce);
              
    }

}
