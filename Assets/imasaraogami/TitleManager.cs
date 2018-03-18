using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour {
    Pushbotton txt;

    [SerializeField] float tim;
	
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
            if (Input.GetKey(KeyCode.A))
            {
                txt.push();
                yield return new WaitForSeconds(tim);
                //---シーンを移動するのを書けばほぼ終わり----------


            　　//-----------------------------------------------
            }


            yield return null;
        }

    }
}
	
	

