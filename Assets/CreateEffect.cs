using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEffect : MonoBehaviour {

    // Use this for initialization
    [SerializeField] GameObject Effect;
    //接地から爆発までの時間
    [SerializeField] float exptime=3;
    
    //爆発範囲設定用
    public float exprad;

    bool expFlag=false;

    private void OnCollisionEnter(Collision collision)
    {
        if (expFlag) return;
        StartCoroutine(Countdown());
        expFlag = true;
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(exptime);
        //爆発エフェクト生成
        var effect = Instantiate(Effect);
        effect.transform.position = transform.position;
        
        //爆発範囲をexprad(float)にする
        var _Effect = Effect.GetComponent<Explosion>();
        _Effect.radius = exprad;

        Destroy(gameObject);

        yield return null;
    }
}
