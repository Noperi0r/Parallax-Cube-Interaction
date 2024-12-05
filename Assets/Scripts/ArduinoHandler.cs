using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoHandler : MonoBehaviour
{
    SerialPort _dataStream = new SerialPort("COM10", 19200);
    string _receivedStr;

    void Start()
    {
        _dataStream.Open();
        if(_dataStream.IsOpen)
            InvokeRepeating("ReadSerialData", 0, 0.001f);
    }

    void Update()
    {
        
    }

    void ReadSerialData()
    {
        _receivedStr = _dataStream.ReadLine();
        string[] datas = _receivedStr.Split(',');
        // TODO
    }
}
