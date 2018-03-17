using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomcreate : MonoBehaviour {
    [SerializeField] GameObject Bom;

	// Use this for initialization
	void Start () {
        StartCoroutine(Createbom());	
	}
	
	// Update is called once per frame
	IEnumerator Createbom()
    {
        while (true)
        {
            var rand = 1;
                //Random.Range(0, 5);
            if (rand == 1)
            {
                var bom = Instantiate(Bom);
            }

            yield return new WaitForSeconds(5.0f);
        }
    }
}
