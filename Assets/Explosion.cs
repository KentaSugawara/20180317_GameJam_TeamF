using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    [SerializeField] public float radius;
    [SerializeField] public int damegehanntei;


    // Use this for initialization
    void Start () {
        //arrayには爆発に当たっているキャラクターobjの配列が入ってる
        StartCoroutine(damegaef(damegehanntei));
        StartCoroutine(Delete());
    }

    IEnumerator damegaef(int frame)
    {
        for (int i = 0; i < frame; i++)
        {
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


	IEnumerator Delete()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
        yield return null;
    }
	
}
