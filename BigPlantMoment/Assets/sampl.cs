using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sampl : MonoBehaviour

{

    // Start is called before the first frame update
    void Start()
    {
        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);
        foreach (var device in inputDevices){
            UnityEngine.Debug.Log(device.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
