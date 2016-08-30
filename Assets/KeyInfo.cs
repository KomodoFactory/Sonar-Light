using UnityEngine;
using System.Collections;

public class KeyInfo : MonoBehaviour {
    public string keyName, opensDoor;
    Key keyObject;
	// Use this for initialization
	void Start () {
        keyObject = new Key(keyName, opensDoor);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public Key getKeyObject()
    {
        return keyObject;
    }
}
