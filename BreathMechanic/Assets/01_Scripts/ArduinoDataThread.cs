using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;

public class ArduinoDataThread : MonoBehaviour
{
    Thread IOThread = new Thread(DataThread);
    private static SerialPort sp;
    private static string incomingMsg = "";
    private static string outcomingMsg = "";
    private string value1;

    private static void DataThread()
    {
        sp = new SerialPort("COM7", 9600);
        sp.Open();

        while (true)
        {
            if(outcomingMsg != "")
            {
                sp.Write(outcomingMsg);
                outcomingMsg = "";
            }
            incomingMsg = sp.ReadExisting();
            //Thread.Sleep(200);

        }
    }

    private void OnDestroy()
    {
        IOThread.Abort();
        sp.Close();
    }
    void Start()
    {
        IOThread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if(incomingMsg != "")
        {
            Debug.Log(incomingMsg);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            outcomingMsg = "0";
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            outcomingMsg = "1";
        }
        
    }
}
