using UnityEngine;

public class MovingManager : MonoBehaviour
{
    [SerializeField] bool _controlBySensor;

    [SerializeField] GameObject _targetObj;
    [SerializeField] SensorHandler _sensorHandler;
    //[SerializeField] float _minRadius;
    //[SerializeField] float _maxRadius;

    [SerializeField] float _upLength;
    [SerializeField] float _decisionTheta;

    [SerializeField] float _linearVelMultiplier = 12f;

    Vector3 _upCircleCenter;
    float _upCircleRadius;
    float _upCircleTheta;

    void Start()
    {
        _upCircleCenter = transform.position + Vector3.up * _upLength;
        _upCircleRadius = _upLength * Mathf.Tan(_decisionTheta * Mathf.Deg2Rad);
    }

    void Update()
    {
        _upCircleCenter = transform.position + Vector3.up * _upLength;
        _upCircleRadius = _upLength * Mathf.Tan(_decisionTheta * Mathf.Deg2Rad);
        
        if (_controlBySensor)    
            TranslateObj();
        
        RegulateTargetPos();
    }
    void TranslateObj()
    {
        // Deprecated 
        //Vector3 posDiff = _sensorHandler.sensorRawVec * Time.deltaTime;  
        //_targetObj.transform.position += posDiff; 

        // Angle update with linear velocity
        float angleDelta = (_sensorHandler.sensorRawVec.x * _linearVelMultiplier / _upCircleRadius) * Time.deltaTime;
        _upCircleTheta += angleDelta;
        _upCircleTheta %= 360;

        float x = _upCircleCenter.x + _upCircleRadius * Mathf.Cos(_upCircleTheta * Mathf.Deg2Rad);
        float z = _upCircleCenter.z + _upCircleRadius * Mathf.Sin(_upCircleTheta * Mathf.Deg2Rad);

        _targetObj.transform.position = new Vector3(x, _targetObj.transform.position.y, z);
    }

    void RegulateTargetPos()
    {
        Transform targetTrans = _targetObj.transform;
        targetTrans.position = new Vector3(targetTrans.position.x, _upCircleCenter.y, targetTrans.position.z);

        Vector3 dir = (targetTrans.position - _upCircleCenter).normalized;

        targetTrans.position = _upCircleCenter + dir * _upCircleRadius;
    }
}
