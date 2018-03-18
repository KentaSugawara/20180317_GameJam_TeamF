using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEffect : MonoBehaviour {

    // Use this for initialization
    [SerializeField] GameObject Effect;
    //接地から爆発までの時間
    [SerializeField] float exptime=3;

    [SerializeField] float exptime2 = 1.5f;

    [SerializeField] ScaleObject ScaleObject;

    //爆発範囲設定用
    public float exprad;

    bool expFlag=false;

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (expFlag) return;
        StartCoroutine(Countdown());
        expFlag = true;
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(exptime);

        ScaleObject.enabled = true;

        yield return new WaitForSeconds(exptime2);
        //爆発エフェクト生成
        var effect = Instantiate(Effect);
        effect.transform.position = transform.position;
        
        //爆発範囲をexplosionradius(float)にする
        var _Effect = Effect.GetComponent<Explosion>();
        _Effect.radius = exprad;

        Destroy(gameObject);

        yield return null;
    }
}
