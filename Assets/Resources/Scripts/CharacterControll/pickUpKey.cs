using UnityEngine;
using System.Collections;
using System;

public class pickUpKey : CourserListener
{
    private static readonly string axisInteract = AxisComponent.Interact;
    private static readonly string[] interestedAxis = {axisInteract};

    CharacterInventory inventory;

    public void initialize()
    {
        inventory = CharacterInventory.Instance;
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
        if (focusedObject.GetComponent<KeyInfo>() != null)
        {
            inventory.addKey(focusedObject.GetComponent<KeyInfo>().getKeyObject());
            UnityEngine.Object.Destroy(focusedObject);
        }
    }
}
