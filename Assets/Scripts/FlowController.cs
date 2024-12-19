using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlowController : MonoBehaviour
{
    [SerializeField] Vector3 _initPosition;
    [SerializeField] GameObject _camObj;

    public void OnReset(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ResetCam();
        }
    }

    void ResetCam()
    {
        Debug.LogWarning("CAM RESET");
        _camObj.transform.position = new Vector3(0, _camObj.transform.position.y, _camObj.transform.position.z);
    }

}
