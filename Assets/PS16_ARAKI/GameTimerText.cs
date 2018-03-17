using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerText : MonoBehaviour
{
    //    [SerializeField]
    private float maxTime = 33.3333333f;
    private float time;
    private Text t;

    // Use this for initialization
    void Start()
    {
        t = GetComponent<Text>();
        time = maxTime;
        t.text = time.ToString("F0");
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
                t.text = time.ToString("F0");
                break;
            }
            else
            {
                t.text = time.ToString("F0");
            }
        }
    }
}
