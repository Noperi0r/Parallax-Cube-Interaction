using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class ESP32Handler : MonoBehaviour
{
    SerialPort _dataStream = new SerialPort("COM5", 115200);
    Thread _readThread;
    object _lockObject = new object();

    bool _keepReading = false;
    public bool keepReading => _keepReading;

    string _receivedStr = "";
    string[] _posInString = new string[3];
    Vector3 _sensorRawPos;
    Vector3 _virtualPos;

    public GameObject testobj;

    public Vector3 GetSensorPos() { return _sensorRawPos; }

    void Start()
    {
        try
        {
            _dataStream.Open();
            if (_dataStream.IsOpen)
            {
                _keepReading = true;
                _readThread = new Thread(ReadSerialData);
                _readThread.Start();
            }
            else
            {
                Debug.LogError("Serial Port Open Failed");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error opening serial port: {ex.Message}");
        }
    }

    void Update()
    {
        lock (_lockObject)
        {
            if (!string.IsNullOrEmpty(_receivedStr))
            {
                Debug.Log(_receivedStr);
                _receivedStr = "";
            }
        }

        Vector3 pos = GetSensorPos();
        //testobj.transform.position = new Vector3(pos.x, 0, pos.z);    
    }

    void ReadSerialData()
    {
        while (_keepReading)
        {
            try
            {
                string data = _dataStream.ReadLine();
                lock (_lockObject)
                {
                    _receivedStr = data;
                    //Debug.Log(_receivedStr);
                    if (char.IsDigit(_receivedStr[0]) || _receivedStr[0] == '-')
                    {
                        _posInString = _receivedStr.Split(',');

                        // Arduino x: right, y: front, z: up 
                        _sensorRawPos.x = float.Parse(_posInString[0]); 
                        _sensorRawPos.y = float.Parse(_posInString[2]);
                        _sensorRawPos.z = float.Parse(_posInString[1]);
                    }
                    else
                    {
                        Debug.LogWarning($"CALIBRATING");
                    }
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogWarning($"Error reading serial data: {ex.Message}");
            }
        }
    }

    void OnApplicationQuit()
    {
        _keepReading = false;
        if (_readThread != null && _readThread.IsAlive)
            _readThread.Join();

        if (_dataStream.IsOpen)
            _dataStream.Close();
    }
}