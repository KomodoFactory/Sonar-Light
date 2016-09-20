using UnityEngine;

public interface CurserListener {

    void initialize();
    void update();
    bool axisFiered(string axis);
    void interactWithFocusedObject(GameObject focusedObject, float distanceToObject);
    string[] getInterestedAxes();
}
