using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDisplay : MonoBehaviour
{
    void Start()
    {
        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON.
        // Check if additional displays are available and activate each.
        if (Display.displays.Length > 1) // 2 idx display detected on OS
            Display.displays[1].Activate();
        if (Display.displays.Length > 2) // 3
            Display.displays[2].Activate();
        if (Display.displays.Length > 3) // 4 
            Display.displays[3].Activate();
        if (Display.displays.Length > 4)
            Display.displays[4].Activate();
        if (Display.displays.Length > 5)
            Display.displays[5].Activate();
        
        // 4> 
    }

}
