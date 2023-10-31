using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int Speed = 5;

    [SerializeField] private ArduinoTest arduinoTest;
    private float xAs;
    private float yAs;
    
    Vector3 MoveDirection;

    Vector3 playerPos;
 

    // Start is called before the first frame update
    void Start()
    {
        playerPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        xAs = arduinoTest.xMovement / 100.0f;
        yAs = arduinoTest.yMovement / 100.0f;

        transform.position = new Vector3 (xAs, 0, yAs);
    }
}
