using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlScript : MonoBehaviour
{
    public static controlScript controlscript;
    public Cinemachine.CinemachineFreeLook cinemachine;
    public bool mouseControl = true;
    void Awake()
    {
        controlscript = this;
        cinemachine = GetComponent<Cinemachine.CinemachineFreeLook>();


    }

    // Update is called once per frame
    void Update()
    {
        //if (OVRManager.isHmdPresent)
        //{

            if (OVRManager.hasVrFocus == true)
            {

                mouseControl = false;
                cinemachine.m_XAxis.m_InputAxisName = "Oculus_CrossPlatform_SecondaryThumbstickHorizontal";
                cinemachine.m_YAxis.m_InputAxisName = "Oculus_CrossPlatform_SecondaryThumbstickVertical";
            }
            else
            {

                mouseControl = true;
                cinemachine.m_XAxis.m_InputAxisName = "MouseX";
                cinemachine.m_YAxis.m_InputAxisName = "MouseY";
            }
        /*}

        else
        {
            mouseControl = true;
            cinemachine.m_XAxis.m_InputAxisName = "MouseX";
            cinemachine.m_YAxis.m_InputAxisName = "MouseY";
        }*/
    }
}
