using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int PlayerHealth;
    [SerializeField] private float MaxSpeed = 3.0f;
    [SerializeField] private float ForceStrenght = 800;
    [SerializeField] private int DamageTaken;

    [SerializeField] private ArduinoTest arduinoTest;


    private Rigidbody playerRb;
    private Vector3 moveDirection;
    private Vector3 defaultMovediretion;

    private float xAs;
    private float yAs;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.drag = 2.0f;
        defaultMovediretion = new Vector3(-0.1f, transform.position.y, -0.1f);
    }

    private void Update()
    {
        xAs = arduinoTest.xMovement / 100.0f;
        yAs = arduinoTest.yMovement / 100.0f;

        if (xAs == -0.1)
        {
            xAs = 0.0f;
        }
        if (yAs == -0.1)
        {
            yAs = 0.0f;
        }
    }

    private void FixedUpdate()
    {
        CalculateMoveDirection();
        Movement();
    }

    public void Movement()
    {
        float _currentSpeed = playerRb.velocity.magnitude;
        //if (_currentSpeed <= MaxSpeed)
        //{
        //    float _verticalForceControl = Input.GetAxis("Vertical");
        //    float _horizontalForceControl = Input.GetAxis("Horizontal");

        //    playerRb.AddForce(Vector3.forward * _verticalForceControl * ForceStrenght);
        //    playerRb.AddForce(Vector3.right * _horizontalForceControl * ForceStrenght);

        //}

        if (_currentSpeed <= MaxSpeed)
        {
            playerRb.AddForce(moveDirection * ForceStrenght);
        }


    }

    public void Jump()
    {
        if (moveDirection != defaultMovediretion)
        {
            playerRb.AddForce(Vector3.up * 10 * ForceStrenght);

        }
    }

    private void CalculateMoveDirection()
    {
        moveDirection = new Vector3(xAs, transform.position.y, yAs);
        Debug.Log("move dir : " + moveDirection);
        Debug.Log("default dir : " + defaultMovediretion);
    }
}
