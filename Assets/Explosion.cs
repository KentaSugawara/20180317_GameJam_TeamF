using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    //爆発(あたり判定)範囲
    [SerializeField] public float radius;
    //この変数いじればダメージ判定のあるフレーム数をいじれる↓
    [SerializeField] public int damegehanntei;


    // Use this for initialization
    void Start () {

        StartCoroutine(damegaef(damegehanntei));

        StartCoroutine(Delete());
    }
    //何フレーム分ダメージ判定を付けるか
    IEnumerator damegaef(int frame)
    {
        for (int i = 0; i < frame; i++)
        {
            //arrayには爆発に当たっているキャラクターobjの配列が入ってる
            var array = Physics.OverlapSphere(transform.position, radius, 1 << 10);
            for (int f = 0; f < array.Length; f++)
            {
                var charscr = array[i].gameObject.GetComponent<test_Character>();
                if (charscr != null)
                {
                    charscr.Damage(1);
                }
            }
            yield return null;
        }
        yield return null;
    }

    //自分消す
	IEnumerator Delete()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
        yield return null;
    }
	
}
