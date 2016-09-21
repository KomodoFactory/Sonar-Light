using UnityEngine;
using System.Collections;

public class ListenerComponent
{
    private CursorListener listener;
    private string[] axis;

    public ListenerComponent(CursorListener listener, string[] axis)
    {
        this.listener = listener;
        this.axis = axis;
    }

    public CursorListener getListener()
    {
        return listener;  
    }

    public string[] getAxis()
    {
        return axis;
    }
}
