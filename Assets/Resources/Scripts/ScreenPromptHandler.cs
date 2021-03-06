﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(Text))]
public class ScreenPromptHandler : MonoBehaviour {

    private static ScreenPromptHandler instance;
    private ScreenPromptHandler() {
        list = new List<ScreenPrompt>();
    }

    static Canvas canvas;
    Text textField;
    System.Text.StringBuilder sb;
    List<ScreenPrompt> list;

    public static ScreenPromptHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = canvas.GetComponent<ScreenPromptHandler>();
            }
            return instance;
        }
    }

    class ScreenPrompt
    {
        public string message;
        public float duration;

        public ScreenPrompt(string msg, float dur)
        {
            message = msg;
            duration = dur;
        }
    }

    // Use this for initialization
    void Start () {
        canvas =  GameObject.FindObjectOfType<Canvas>();
        textField = GameObject.Find("PromptText").GetComponent<Text>();
        sb = new System.Text.StringBuilder();
    }
	
	// Update is called once per frame
	void Update () {
        if (list != null)
        {
            updateTimers();
            deleteExpiredPrompts();
            buildText();
            textField.text = sb.ToString();
        }
	}
    void updateTimers()
    {
        if (list.Count > 0)
        {
            foreach (ScreenPrompt prompt in list)
            {
                prompt.duration -= Time.deltaTime;
            }
        }
    }

    void deleteExpiredPrompts()
    {
        if (list.Count > 0)
        {
            foreach (ScreenPrompt prompt in list.ToList())
            {
                if (prompt.duration < 0)
                {
                    list.Remove(prompt);
                }
            }
        }
    }

    void buildText()
    {
        textField.text = "";
        sb.Remove(0, sb.Length);
        if (list.Count > 0)
        {
            foreach (ScreenPrompt prompt in list.ToList())
            {
                sb.AppendLine(prompt.message);
            }
        }
    }

    public void DisplayPrompt(string msg, float dur)
    {
        //Debug.Log("Display Prompt called!");
        if (msg != null && msg != "" && dur > 0)
        {
            ScreenPrompt sp = new ScreenPrompt(msg, dur);
            //Debug.Log("Msg: " + sp.message + " Dur: " + sp.duration);
            list.Add(sp);
            //Debug.Log(list.Count);
        }
    }
}
