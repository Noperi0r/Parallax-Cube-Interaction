using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class MoveRestrictor : MonoBehaviour
{
    [SerializeField] GameObject _targetObj;
    [SerializeField] float _radius;

    void ControlTargetPos()
    {
        Vector3 targetPos = _targetObj.transform.position;
        Vector3 center = transform.position;

        float dist = Vector3.Distance(targetPos, center);

        //if (dist > _radius)
        //{ 
            Vector3 dir = (targetPos - center).normalized;
            _targetObj.transform.position = center + dir * _radius;
        //}

    }
    void Update()
    {
        ControlTargetPos();    
    }
}
