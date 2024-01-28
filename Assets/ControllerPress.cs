using System.Collections;
using System.Collections.Generic;
using Leap;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.Video;

public class ControllerPress : MonoBehaviour
{
    [SerializeField]
    private GameObject _leapTransform;

    private XRController _rightHand;

    void Update(){
        var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);
        bool triggerValue;
        if(rightHandDevices.Count > 0){
            if (rightHandDevices[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
            {
                _leapTransform.transform.position = transform.position;
                _leapTransform.transform.rotation = Quaternion.Euler(0,Quaternion.LookRotation((_leapTransform.transform.position - Camera.main.transform.position).normalized,Vector3.up) .eulerAngles.y,0);
            }
        }
    }
}
