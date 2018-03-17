using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZibakuTest : MonoBehaviour {
    public float deathTime=3.0f;
    private void Start()
    {
        StartCoroutine(SelfDeath());
    }
    IEnumerator SelfDeath()
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }
}
