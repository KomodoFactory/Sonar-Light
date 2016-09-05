using UnityEngine;
using System.Collections;

public class Key {

    string keyName;
    GameObject opensDoor;
    
    public Key(string name, GameObject opens)
    {
        KeyName = name;
        OpensDoor = opens;
    }

    public string KeyName
    {
        get
        {
            return keyName;
        }

        set
        {
            keyName = value;
        }
    }

    public GameObject OpensDoor
    {
        get
        {
            return opensDoor;
        }

        set
        {
            opensDoor = value;
        }
    }
}
