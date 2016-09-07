using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(Text))]
public class CharacterInventory : MonoBehaviour {
    private static CharacterInventory instance;
    private CharacterInventory()
    {
        keyList = new List<object>();
    }
    List<object> keyList;
    Text keyText;
    System.Text.StringBuilder sb;

    public static CharacterInventory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInventory>();
            }
            return instance;
        }
    }
    // Use this for initialization
    void Start () {
        keyText = GameObject.Find("KeyText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (keyText != null)
        {
            displayKeys();
        }
    }

    public void addKey(Key key)
    {
        //Debug.Log("Add Key has been called!");
        if (key != null)
        {
            keyList.Add(key);
        }
    }

    void displayKeys()
    {
        if (keyList.Count > 0)
        {
            sb = new System.Text.StringBuilder();
            sb.Append("Current Keys:\n");
            foreach (Key key in keyList)
            {
                sb.AppendLine(key.KeyName);
            }
            keyText.text = sb.ToString();
        }
    }

    public bool checkIfDoorCanBeOpened(GameObject door)
    {
        foreach(Key key in keyList.ToList())
        {
            if (key.OpensDoor == door)
            {
                keyList.Remove(key);
                return true;
            }
        }
        return false;
    }
}
