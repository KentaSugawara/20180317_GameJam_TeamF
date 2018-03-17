using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    [SerializeField] float radius;


	// Use this for initialization
	void Start () {
        StartCoroutine(Delete());
        var array = Physics.OverlapSphere(transform.position, radius, 1 << 10);
        for(int i = 0; i < array.Length; i++)
        {
            var charscr = array[i].gameObject.GetComponent<test_Character>();
            if (charscr != null)
            {
                charscr.Damage(1);
            }
        }
    }
	IEnumerator Delete()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
        yield return null;
    }
	
}
