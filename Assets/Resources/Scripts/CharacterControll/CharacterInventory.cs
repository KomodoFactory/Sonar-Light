using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(Text))]
public class CharacterInventory : MonoBehaviour {
    private static CharacterInventory instance;
    private static readonly string lineBreak = System.Environment.NewLine;
    private List<object> keyList;
    private int coinAmount;
    private Text keyText;
    private Text coinText;
    private System.Text.StringBuilder keyStringBuilder;
    private System.Text.StringBuilder coinStringBuilder;

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

    private CharacterInventory()
    {
        keyList = new List<object>();
        coinAmount = 0;
    }
    
    void Start ()
    {
        keyText = GameObject.Find("KeyText").GetComponent<Text>();
        coinText = GameObject.Find("CoinText").GetComponent<Text>();
        keyStringBuilder = new System.Text.StringBuilder();
        coinStringBuilder = new System.Text.StringBuilder();
    }
	
	void Update () {
        if (keyText != null || coinText != null)
        {
            displayInventory();
        }
    }

    void displayInventory()
    {
        if (keyList.Count > 0)
        {
            keyStringBuilder.Append("Current Keys:" + lineBreak);
            foreach (Key key in keyList)
            {
                keyStringBuilder.AppendLine(key.KeyName + lineBreak);
            }
            keyText.text = keyStringBuilder.ToString();
            keyStringBuilder.Remove(0, keyStringBuilder.Length);
        }

        if (coinAmount > 0)
        {
            coinStringBuilder.Append("Coins found:" + lineBreak);
            coinStringBuilder.AppendLine(coinAmount + lineBreak);
            coinText.text = coinStringBuilder.ToString();
            coinStringBuilder.Remove(0, coinStringBuilder.Length);
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

    public void addKey(Key key)
    {
        if (key != null)
        {
            keyList.Add(key);
        }
    }

    public void addCoin()
    {
        Debug.Log("Coin!");
        coinAmount++;
    }

}
