using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class ArduinoTest : MonoBehaviour
{

    private SerialPort dataStream = new SerialPort("COM7", 9600); // luister naar "eën seriale port maakt niet uit welke"
    // Start is called before the first frame update
    void Start()
    {
        dataStream.Open();
    }

    // Update is called once per frame
    void Update()
    {
        string value = dataStream.ReadLine();
        Debug.Log(value);
    }
}
