using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouchBehaviour : MonoBehaviour
{

    [SerializeField] float baseMoveSpeed = 10.0f;
    [SerializeField] float baseMaxHorizontalMoveSpeed = 5f;
    [SerializeField] float baseMaxVerticalMoveSpeed = 5f;
    [SerializeField] Joystick joystick;

    private float currentMoveSpeed;
    private Rigidbody2D myBody;

    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        currentMoveSpeed = baseMoveSpeed;

    }

    private void Update()
    {
        MovePlayerHorizontally();
        MovePlayerVertically();
        ThrottlePlayerVelocity();
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
        float yVelocityMax = Mathf.Clamp(myBody.velocity.x, -baseMaxVerticalMoveSpeed, baseMaxVerticalMoveSpeed);

        myBody.velocity = new Vector2(xVelocityMax, yVelocityMax);        
    }

}
