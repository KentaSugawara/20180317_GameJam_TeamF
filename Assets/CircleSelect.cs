using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSelect : MonoBehaviour {
    [SerializeField]
    int characterValue;
    float radius;
    GameObject[] charaFace;
    int sss;
    int SelectCharaNum
    {
        set
        {
            charaFace[sss].transform.localScale = new Vector3(1.0f,1.0f,1.0f);
            sss = value;
            charaFace[sss].transform.localScale *= 2.0f;
        }
        get
        {
            return sss;
        }
    }
	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SelectCharaNum--;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SelectCharaNum++;
        }
        if (SelectCharaNum<0)
        {
            SelectCharaNum=charaFace.Length;
        }
        if (SelectCharaNum>charaFace.Length)
        {
            SelectCharaNum = 0;
        }
    }
}
