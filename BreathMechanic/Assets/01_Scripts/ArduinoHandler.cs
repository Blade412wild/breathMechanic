using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class ArduinoHandler : MonoBehaviour
{
    private SerialPort stream = new SerialPort("COM7", 9600);

    Dictionary<string, int> hardwareVars = new Dictionary<string, int>();
    private string line = "";

    public int xAsValue { get; private set; }
    public int yAsValue { get; private set; }

    public bool ButtonPressed { get; private set; }

    public UnityEvent OnButtonPressed;

    Thread thread;

    private void Start()
    {
        stream.Open();
        stream.ReadTimeout = 100;

        thread = new Thread(new ThreadStart(ReadFromStream));
        thread.Start();
    }

    private void OnDisable()
    {
        thread.Abort();
        stream.Close();
    }

    private void Update()
    {
        //xAsValue = hardwareVars["xAs"];
        //yAsValue = hardwareVars["yAs"];

        if (ButtonPressed)
        {
            OnButtonPressed.Invoke();
        }
        //Debug.Log("SunPotValue : " + SunPotValue + "buttun state : " + hardwareVars["button"]);
    }

    private void ReadFromStream()
    {
        // Splits read data and saves it in the corresponding properties
        while (thread.IsAlive)
        {
            try
            {
                line = stream.ReadLine();
            }
            catch (TimeoutException) { }
            Debug.Log(line);

            string[] parts = line.Split(",");

            foreach (string part in parts)
            {
                string[] keyValue = part.Split(":");
                string key = keyValue[0];
                int value = int.Parse(keyValue[1]);
                hardwareVars[key] = value;
            }

            //if (hardwareVars["button"] == 0)
            //{
            //    ButtonPressed = true;
            //}
            //else
            //{
            //    ButtonPressed = false;
            //}
        }
    }
}