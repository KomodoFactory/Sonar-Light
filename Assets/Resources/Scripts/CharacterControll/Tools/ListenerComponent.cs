using UnityEngine;
using System.Collections;

public class ListenerComponent
{
    private CurserListener listener;
    private string[] axis;

    public ListenerComponent(CurserListener listener, string[] axis)
    {
        this.listener = listener;
        this.axis = axis;
    }

    public CurserListener getListener()
    {
        return listener;  
    }

    public string[] getAxis()
    {
        return axis;
    }
}
