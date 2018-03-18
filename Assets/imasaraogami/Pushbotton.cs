using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pushbotton : MonoBehaviour {
    Text txt;
    float a = 1.0f;
	// Use this for initialization
	void Start () {
        //txt=GetComponent<Text>();
    }
	
    public void colchange()
    {
        StartCoroutine(colorchange());
    }

    private void Awake()
    {
        txt = GetComponent<Text>();
    }

    public void push()
    {
        StartCoroutine(botanositayo());
    }

    IEnumerator colorchange()
    {
        while (true)
        {
            while (txt.color.a > 0)
            {
                txt.color += new Color(0, 0, 0, -1.0f * Time.deltaTime);
                yield return null;
            }

            while (txt.color.a < 1)
            {
                txt.color += new Color(0, 0, 0, 1.0f * Time.deltaTime);
                yield return null;
            }

            yield return null;
            
        }
    }
    
    IEnumerator botanositayo()
    {
        while (true)
        {
            while (txt.color.a > 0)
            {
                txt.color += new Color(0, 0, 0, -10.0f * Time.deltaTime);
                yield return null;
            }

            while (txt.color.a < 1)
            {
                txt.color += new Color(0, 0, 0, 10.0f * Time.deltaTime);
                yield return null;
            }
            yield return null;
        }
    }

}
