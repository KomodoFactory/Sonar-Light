using UnityEngine;
using System.Collections;

public class SpawnCan : MonoBehaviour
{
    private GameObject can;

    void Start()
    {
        can = Resources.Load("GameObjects/WorldObjects/Interactable/Can") as GameObject;
    }

    public void interact()
    {
        if (can != null)
        {
            SoundRegistry.getInstance().addSound(new Sound(this.transform.gameObject, 20, SoundComponent.audioByName("vendingmachine")));
            Vector4 translateVector = this.gameObject.transform.localToWorldMatrix * new Vector3(0, 0, 0);
            translateVector /= translateVector.w;
            GameObject canObj = GameObject.Instantiate(can);
            canObj.transform.parent = this.gameObject.transform;
            canObj.transform.localPosition = new Vector3(0.01287f, 0.01198f, 0.01295f);
            canObj.transform.localRotation = Quaternion.Euler(new Vector3(89.981f, 90f, 0f));
        }
    }
}
