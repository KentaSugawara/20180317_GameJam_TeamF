﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterSelectManager : MonoBehaviour
{
    public CharacterSelect p1;
    public CharacterSelect p2;
    public string[] skillNames;
    public GameObject[] charaFlames;
    public Sprite[] charaSprites;
    public Image[]  charaImgs;
    private void Awake()
    {
        for (int i=0;i<charaImgs.Length;i++)
        {
            charaImgs[i].sprite = charaSprites[i];
        }
    }
}