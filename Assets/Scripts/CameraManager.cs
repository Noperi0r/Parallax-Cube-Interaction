using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] List<Camera> _cams = new List<Camera>();
    [SerializeField] ESP32Handler _esp32Handler;

    void Start()
    {
        for(int i=0; i< transform.childCount; ++i)
        {
            Camera cam = transform.GetChild(i).GetComponent<Camera>();
            if (cam)
                _cams.Add(transform.GetChild(i).GetComponent<Camera>());
        }
    }

    void Update()
    {
        // TODO: Sensor on trigger
    }

}
