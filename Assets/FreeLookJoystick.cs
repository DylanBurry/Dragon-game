using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FreeLookJoystick : MonoBehaviour
{
    private CinemachineFreeLook cinemachine;
    void Start()
    {
        cinemachine = GetComponent<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update()
    {
        cinemachine.m_XAxis.m_InputAxisValue = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch).x;
        cinemachine.m_YAxis.m_InputAxisValue = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch).y;

    }
}
