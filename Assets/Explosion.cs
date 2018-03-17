using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Delete());
    }
	IEnumerator Delete()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
        yield return null;
    }
	
}
