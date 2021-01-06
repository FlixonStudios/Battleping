using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField]  public Joystick joystick;

    Rigidbody2D myBody;

    private float horizontalMove;

    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMove = joystick.Horizontal * moveSpeed;

        myBody.velocity = new Vector2(horizontalMove, myBody.velocity.y);

    }
}
