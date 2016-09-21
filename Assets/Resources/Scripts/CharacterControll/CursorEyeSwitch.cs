using UnityEngine;
using System.Collections;
using System;

public class CursorEyeSwitch : CursorListener
{
    private EyeSwitch eyeSwitch;
     
    public void initialize()
    {

    }

    public void update()
    {

    }

    public bool axisFiered(string axis)
    {
        if (axis.Equals(AxisComponent.Interact))
        {
            return true;
        }
        return false;
    }

    public void interactWithFocusedObject(GameObject focusedObject, float distanceToObject)
    {
        if (focusedObject != null)
        {
            eyeSwitch = focusedObject.GetComponent<EyeSwitch>();
            if (eyeSwitch != null)
            {
                if (distanceToObject <= 4)
                {
                    eyeSwitch.activateSwitch();
                }
            }
        }
    }

    public string[] getInterestedAxes()
    {
        String[] axis = new String[1];
        axis[0] = AxisComponent.Interact;
        return axis;
    }
}
