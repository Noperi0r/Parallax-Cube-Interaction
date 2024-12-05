using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Transform _cubeCenter;
    [SerializeField] List<Camera> _cams = new List<Camera>();

    Vector3 _camToCenterVec;

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
        //_camToCenterVec = _cubeCenter.position - transform.position;
        //Quaternion.LookRotation(_camToCenterVec);
    }



}
