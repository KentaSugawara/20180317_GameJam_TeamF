using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour {
    [SerializeField]
    private Vector3 _StartScale;

    [SerializeField]
    private Vector3 _StartToEndScaleBezier;

    [SerializeField]
    private float _StartToEndSeconds;

    [SerializeField]
    private Vector3 _EndScale;

    [SerializeField]
    private Vector3 _EndToStartScaleBezier;

    [SerializeField]
    private float _EndToStartSeconds;

    [SerializeField]
    private float _Interval;

    private void OnEnable()
    {
        StartCoroutine(Routine_Main());
    }

    private IEnumerator Routine_Main()
    {
        Vector3 b1, b2;
        while (true)
        {
            for (float t = 0.0f; t < _StartToEndSeconds; t += Time.deltaTime)
            {
                float e = t / _StartToEndSeconds;
                b1 = Vector3.Lerp(_StartScale, _StartToEndScaleBezier, e);
                b2 = Vector3.Lerp(_StartToEndScaleBezier, _EndScale, e);
                transform.localScale = Vector3.Lerp(b1, b2, e);
                yield return null;
            }

            transform.localScale = _EndScale;

            yield return new WaitForSeconds(_Interval);

            for (float t = 0.0f; t < _EndToStartSeconds; t += Time.deltaTime)
            {
                float e = t / _EndToStartSeconds;
                b1 = Vector3.Lerp(_EndScale, _StartToEndScaleBezier, e);
                b2 = Vector3.Lerp(_StartToEndScaleBezier, _StartScale, e);
                transform.localScale = Vector3.Lerp(b1, b2, e);
                yield return null;
            }

            transform.localScale = _StartScale;

            yield return new WaitForSeconds(_Interval);
        }
    }
}
