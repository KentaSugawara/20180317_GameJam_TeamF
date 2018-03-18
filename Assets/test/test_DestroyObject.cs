using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_DestroyObject : MonoBehaviour {
    [SerializeField]
    private float _DestroySeconds;

	private void Start () {
        StartCoroutine(Rotine_Main());
	}

    private IEnumerator Rotine_Main()
    {
        for (float t = 0.0f; t < _DestroySeconds; t += Time.deltaTime)
        {
            yield return null;
        }
        Destroy(gameObject);
    }
}
