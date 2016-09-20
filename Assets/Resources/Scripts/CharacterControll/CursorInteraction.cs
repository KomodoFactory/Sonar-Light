using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class CursorInteraction : MonoBehaviour
{
    private static List<ListenerComponent> listeners = new List<ListenerComponent>();
    private Dictionary<string, AxisHandler> handlers = new Dictionary<string, AxisHandler>();
    private GameObject raycastObject;
    public float interactionDistance = 6;
    private float lastRaycastDistance = 0;
    private Vector3 cameraForward;
    private static bool listAllocated = false;

    void Start () {
        collectingListeners();

        foreach(ListenerComponent com in listeners)
        {
            foreach (string axis in com.getAxis())
            {
                if(!handlers.ContainsKey(axis)){
                    handlers.Add(axis, new AxisHandler(axis));
                }
            }
        }
        foreach (ListenerComponent listenerComp in listeners)
        {
            listenerComp.getListener().initialize();
        }

    }
	
	void Update () {
        raycastObject = null;
        foreach(string axis in handlers.Keys)
        {
            handlers[axis].Update();
            if (handlers[axis].pressedDown()) {
               foreach(ListenerComponent listenerComp in listeners)
                {
                    if (listenerComp.getListener().axisFiered(axis))
                    {
                        if (raycastObject == null)
                        {
                            raycastObject = getObjectInRange();
                        }
                        listenerComp.getListener().interactWithFocusedObject(raycastObject, lastRaycastDistance);
                    }
                } 
            }
        }

        foreach (ListenerComponent listenerComp in listeners)
        {
            listenerComp.getListener().update();
        }
    }



    private GameObject getObjectInRange()
    {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(CameraForwardProvider.mainCameraPosition, CameraForwardProvider.mainCameraForward, out hit))
        {
            lastRaycastDistance= hit.distance;
            if (lastRaycastDistance <= interactionDistance)
            {
                return hit.collider.gameObject;
            }
        }
        return null;
    }

    public static void registerCourserListener(CurserListener listener, params string[] axis)
    {
        listeners.Add(new ListenerComponent(listener, axis));
    }

    private void collectingListeners()
    {
        if (!listAllocated) {
            Type type = typeof(CurserListener);
            IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract);

            foreach (Type typ in types) {
                CurserListener cours = ((CurserListener)Activator.CreateInstance(typ));
                listeners.Add(new ListenerComponent(cours, cours.getInterestedAxes()));
            }
            listAllocated = true;
        }
    }
}
