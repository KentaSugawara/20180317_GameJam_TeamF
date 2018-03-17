using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEffect : MonoBehaviour {

    // Use this for initialization
    [SerializeField] GameObject Effect;
    [SerializeField] float exptime=3;

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
        var effect = Instantiate(Effect);
        effect.transform.position = transform.position;

        Destroy(gameObject);

        yield return null;
    }
}
