using System;
using System.IO.Ports;
using TMPro;
using UnityEngine;

public class ArduinoTest : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI port1;
    [SerializeField] private TextMeshProUGUI port2;
    [SerializeField] private TextMeshProUGUI port3;
    [SerializeField] private TextMeshProUGUI port4;
    [SerializeField] private TextMeshProUGUI port5;
    [SerializeField] private TextMeshProUGUI port6;
    [SerializeField] private TextMeshProUGUI port7;
    [SerializeField] private TextMeshProUGUI port8;
    string[] ports;
    int counter;
    //private SerialPort dataStream = new SerialPort("COM7", 9600); // luister naar "eën seriale port maakt niet uit welke"
    // Start is called before the first frame updat
    void Start()
    {
        counter = 0;
        //dataStream.Open();

        // Get a list of serial port names.
        ports = SerialPort.GetPortNames();

        Debug.Log("The following serial ports were found:");

        // Display each port name to the console.
        foreach (string port in ports)
        {
            counter++;
            Debug.Log(port);
            AssigningPort(counter, port);

        }

    }

    // Update is called once per frame
    void Update()
    {
        //string value = dataStream.ReadLine();
        //Debug.Log(value);
    }
    private void AssigningPort(int i, string name)
    {
        switch(i)
        {
            case 1: port1.text = name; break;
            case 2: port2.text = name; break;
            case 3: port3.text = name; break;
            case 4: port4.text = name; break;
            case 5: port5.text = name; break;
            case 6: port6.text = name; break;
            case 7: port7.text = name; break;
            case 8: port8.text = name; break;

        }
    }
}
