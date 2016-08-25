using UnityEngine;
using System.Collections;

public class AxisHandler{

    public string axisTooCheck = "JostickButton0";
    float lastState = 0;
    float newState = 0;

    public AxisHandler(string axisTooCheck)
    {
        this.axisTooCheck = axisTooCheck;
    }

    public void Update()
    {
        lastState = newState;
        newState = Input.GetAxis(axisTooCheck);
    }


    public bool pressedDown()
    {
        return (lastState == 0 && newState == 1);
    }

    public bool pressed()
    {
        return (newState == 1);
    }

    public bool released()
    {
        return (lastState == 1 && newState == 0);
    }

}
