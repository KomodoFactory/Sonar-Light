using UnityEngine;
using System.Collections;

public class CourserInteraction : MonoBehaviour
{
    private Transform cameraTransform;
    private AxisHandler axisFire1;
    private AxisHandler axisFire2;

    // Use this for initialization
    void Start () {
        PickupObjects.Start();

        cameraTransform = Camera.main.transform;
        
        axisFire1 = new AxisHandler("Fire1");
        axisFire2 = new AxisHandler("Fire2");
    }
	
	// Update is called once per frame
	void Update () {

        axisFire1.Update();
        axisFire2.Update();

    }
}
