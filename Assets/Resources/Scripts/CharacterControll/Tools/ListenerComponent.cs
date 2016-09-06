using UnityEngine;
using System.Collections;

public class ListenerComponent
{
    private CourserListener listener;
    private string[] axis;

    public ListenerComponent(CourserListener listener, string[] axis)
    {
        this.listener = listener;
        this.axis = axis;
    }

    public CourserListener getListener()
    {
        return listener;  
    }

    public string[] getAxis()
    {
        return axis;
    }
}
