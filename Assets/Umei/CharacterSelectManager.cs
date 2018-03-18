using System.Collections;
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
    public string[] charaNames;
    private void Start()
    {
        StartCoroutine(GoNext());
    }
    public  void SelectTrigger()
    {
        for (int i=0;i<charaFlames.Length;i++)
        {
            //どちらかにセレクトされていたら
            if (p1.SelectCharaNumber==i||p2.SelectCharaNumber==i)
            {
                charaImgs[i].GetComponent<Animator>().SetBool("RunFlag",true);
            }
            else
            {
                charaImgs[i].GetComponent<Animator>().SetBool("RunFlag", false);
            }
        }
    }
    IEnumerator GoNext()
    {
        while (true)
        {
            if (p1.CharaSelectEnterFlag&&p2.CharaSelectEnterFlag)
            {
                
            }
            yield return null;
        }
    }
}
