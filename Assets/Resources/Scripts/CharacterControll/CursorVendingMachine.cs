﻿using UnityEngine;
using System.Collections;
using System;

public class CursorVendingMachine : CursorListener
{
    private static readonly string axisInteract = AxisComponent.Interact;
    private static readonly string[] interestedAxis = {axisInteract};

    public void initialize()
    {
    }

    public void update()
    {
    }

    public string[] getInterestedAxes()
    {
        return interestedAxis;
    }

    public bool axisFiered(string axis)
    {
        if (axis.Equals(axisInteract))
        {
            return true;
        }
        return false;
    }

    public void interactWithFocusedObject(GameObject focusedObject, float distanceToObject)
    {
        if (focusedObject != null && focusedObject.GetComponent<SpawnCan>() != null)
        {
            focusedObject.GetComponent<SpawnCan>().interact();
        }
    }
}
