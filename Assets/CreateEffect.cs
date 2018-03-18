using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEffect : MonoBehaviour {

    // Use this for initialization
    [SerializeField] GameObject Effect;
    //接地から爆発までの時間
    [SerializeField] public float exptime=3;

    [SerializeField] public float exptime2 = 1.5f;

    [SerializeField] ScaleObject ScaleObject;

    [SerializeField]
    private GameObject _Prefab_Audio_Bomb;

    [SerializeField]
    public bool _isMoving;

    [SerializeField]
    private GameObject _SpriteObj;
    public GameObject SpriteObj
    {
        get { return _SpriteObj; }
    }

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

        ScaleObject.enabled = true;

        yield return new WaitForSeconds(exptime2);
        //爆発エフェクト生成
        var effect = Instantiate(Effect);
        effect.transform.position = transform.position;
        
        //爆発範囲をexprad(float)にする
        var _Effect = Effect.GetComponent<Explosion>();
        _Effect.radius = exprad;

        Instantiate(_Prefab_Audio_Bomb);
        Destroy(gameObject);

        yield return null;
    }
}
