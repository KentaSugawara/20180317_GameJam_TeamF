using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEffect : MonoBehaviour {

    // Use this for initialization
    [SerializeField] GameObject Effect;

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(3.0f);
        var effect = Instantiate(Effect);
        effect.transform.position = transform.position;

        Destroy(gameObject);

        yield return null;
    }
}
