using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnDamageEffect : MonoBehaviour {
    [SerializeField]
    private Image _Image;

    [SerializeField]
    private float _EffectSeconds;

    private float _ReminingSeconds;

    [SerializeField]
    private float _StartAlpha;

    [SerializeField, Range(0.0f, 1.0f)]
    private float _EffectBezier;

    private void Start()
    {
        StartCoroutine(Routine_Main());
    }

    public void IncrementTimer()
    {
        _ReminingSeconds = _EffectSeconds;
    }

    private IEnumerator Routine_Main()
    {
        float b1, b2;
        while (true)
        {
            var color = _Image.color;
            if (_ReminingSeconds <= 0.0f)
            {
                color.a = 0.0f;                
            }
            else
            {
                _ReminingSeconds -= Time.deltaTime;
                float e = 1.0f - _ReminingSeconds / _EffectSeconds;
                b1 = Mathf.Lerp(_StartAlpha, _EffectBezier, e);
                b2 = Mathf.Lerp(_EffectBezier, 0.0f, e);
                color.a = Mathf.Lerp(b1, b2, e);
            }
            _Image.color = color;
            yield return null;
        }
    }
}
