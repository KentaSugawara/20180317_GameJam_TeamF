using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_StartEffect : MonoBehaviour
{
    [SerializeField]
    private float _EffectInterval;

    [SerializeField]
    private List<Text> _Texts = new List<Text>();

    public IEnumerator Routine_Effect()
    {
        for (int i = 0; i < _Texts.Count - 1; ++i)
        {
            _Texts[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(_EffectInterval);
            _Texts[i].gameObject.SetActive(false);
        }

        StartCoroutine(Routine_LastText());
    }

    private IEnumerator Routine_LastText()
    {
        _Texts[_Texts.Count - 1].gameObject.SetActive(true);
        yield return new WaitForSeconds(_EffectInterval);
        _Texts[_Texts.Count - 1].gameObject.SetActive(false);
    }
}
