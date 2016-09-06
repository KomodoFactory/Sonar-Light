using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class CourserInteraction : MonoBehaviour
{
    private static List<ListenerComponent> listeners = new List<ListenerComponent>();
    private Dictionary<string, AxisHandler> handlers = new Dictionary<string, AxisHandler>();
    private GameObject raycastObject;
    public float interactionDistance = 6;
    private float lastRaycastDistance = 0;
    private Transform cameraTransform;

    void Start () {
        collectingListeners();

        cameraTransform = Camera.main.transform;
        
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
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit))
        {
            lastRaycastDistance= hit.distance;
            if (lastRaycastDistance <= interactionDistance)
            {
                return hit.collider.gameObject;
            }
        }
        return null;
    }

    public static void registerCourserListener(CourserListener listener, params string[] axis)
    {
        listeners.Add(new ListenerComponent(listener, axis));
    }

    private void collectingListeners()
    {
        Type type = typeof(CourserListener);
        IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => type.IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract);

        foreach(Type typ in types)
        {
            CourserListener cours = ((CourserListener)Activator.CreateInstance(typ));
            listeners.Add(new ListenerComponent(cours, cours.getInterestedAxes()));
        }
    }
}
