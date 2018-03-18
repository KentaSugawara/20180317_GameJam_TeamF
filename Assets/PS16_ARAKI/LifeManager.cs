using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{

    [SerializeField, Range(1, 2)]
    private int player;
    private int maxLife;
    private bool damage;
    private int nowDamage = 0;
    private float count = 0;

    public bool isDead
    {
        get { return nowDamage >= maxLife; }
    }

    public void PlayerDamageOn()
    {
        damage = true;
    }



    // Use this for initialization
    void Start()
    {
        int count = transform.childCount;
        maxLife = count;
        StartCoroutine(Startroutine_Life());
    }
    IEnumerator Startroutine_Life()
    {
        while (true)
        {
            yield return null;
            if (damage == true)
            {
                GameObject obj = transform.GetChild(nowDamage).gameObject;
                obj.active = false;
                ++nowDamage;
                //if (nowDamage == maxLife)
                //{
                //    nowDamage = maxLife - 1;
                //}
                Debug.Log(obj.name);
                damage = false;
            }
            //if(count>=5){
            //    count -= 5;
            //    PlayerDamageOn();
            //}
            count += Time.deltaTime;
        }
    }
}
