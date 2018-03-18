﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerText : MonoBehaviour
{
    //[SerializeField]
    private float maxTime = 60.0f;
    private float time;
    private Text t;
    private string F = "F1";
    // Use this for initialization
    void Start()
    {
        t = GetComponent<Text>();
        time = maxTime;
        t.text = time.ToString(F);
        StartCoroutine(StartTimer());
    }
    IEnumerator StartTimer()
    {
        while (true)
        {
            yield return null;
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = 0;
                t.text = time.ToString(F);
                break;
            }
            else
            {
                t.text = time.ToString(F);
            }
        }
    }
}
