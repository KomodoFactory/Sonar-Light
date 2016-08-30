using UnityEngine;
using System.Collections;

public class Key {

    string keyName;
    string opensDoor;
    
    public Key(string name, string opens)
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

    public string OpensDoor
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
