using UnityEngine;

public interface CourserListener {

    void initialize();
    void update();
    bool axisFiered(string axis);
    void interactWithFocusedObject(GameObject focusedObject, float distanceToObject);
    string[] getInterestedAxes();
}
