using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour {
    Pushbotton txt;

    [SerializeField] float tim;
    [SerializeField] MoveScene aaaa;
    // Use this for initialization
    void Start () {
        txt=GetComponentInChildren<Pushbotton>();
        StartCoroutine(mainloop());
        txt.colchange();
    }

    IEnumerator mainloop()
    {
        while (true)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {
                txt.push();
                aaaa.NextScene();
            }


            yield return null;
        }

    }
}
	
	

