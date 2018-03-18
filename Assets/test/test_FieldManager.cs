using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_FieldManager : MonoBehaviour {

    [SerializeField]
    private Transform _Field1;

    [SerializeField]
    public float _BombScaleToField1;

    [SerializeField]
    private Transform _Field2;

    [SerializeField]
    public float _BombScaleToField2;

    [SerializeField]
    private test_Character _Character_1;

    [SerializeField]
    private List<Collider> _Fields1 = new List<Collider>(); 

    [SerializeField]
    private test_Character _Character_2;

    [SerializeField]
    private List<Collider> _Fields2 = new List<Collider>();

    [SerializeField]
    private GameObject _Prefab_Audio_MoveBomb;

    [SerializeField]
    private float _MoveBombNeedSeconds;

    [SerializeField]
    private GameObject _Effect;

    private void Start()
    {
        StartCoroutine(Routine_Main());
    }

    private IEnumerator Routine_Main()
    {
        while (true)
        {
            setCollider1(!_Character_1.isUpperVector());
            setCollider2(!_Character_2.isUpperVector());
            yield return new WaitForFixedUpdate();
        }
    }

    public void setCollider1(bool value)
    {
        foreach(var col in _Fields1)
        {
            col.enabled = value;
        }
    }

    public void setCollider2(bool value)
    {
        foreach (var col in _Fields2)
        {
            col.enabled = value;
        }
    }

    //public void MoveObject(Transform target, bool ToField2)
    //{
    //    Transform filed;
    //    if (ToField2)
    //    {
    //        filed = _Field2;
    //    }
    //    else
    //    {
    //        filed = _Field1;
    //    }

    //    target.SetParent(filed, false);
    //}

    public void MoveBomb(CreateEffect target, bool ToField2)
    {
        if (target == null) return;
        if (target._isMoving) return;

        Transform field;
        if (ToField2)
        {
            field = _Field2;
            target.exprad = _BombScaleToField2;
        }
        else
        {
            field = _Field1;
            target.exprad = _BombScaleToField1;
        }
        target.exptime2 += 1.0f + _MoveBombNeedSeconds * 2.0f;

        StartCoroutine(Routine_MoveBomb(target, field));
    }

    private IEnumerator Routine_MoveBomb(CreateEffect target, Transform filed)
    {
        if (target) target._isMoving = true;

        Vector3 Scale = target.SpriteObj.transform.localScale;

        Vector3 b;

        //縮小
        for (float t = 0.0f; t < _MoveBombNeedSeconds; t += Time.deltaTime)
        {
            float e = t / _MoveBombNeedSeconds;
            b = Vector3.Lerp(Scale, Vector3.zero, e);
            if (target) target.SpriteObj.transform.localScale = Vector3.Lerp(b, Vector3.zero, e);
            yield return null;
        }
        if (target) target.SpriteObj.transform.localScale = Vector3.zero;

        //移動
        if (target)
        {
            target.transform.SetParent(filed, false);
            Instantiate(_Effect, target.transform.position, Quaternion.identity);
        }
        Instantiate(_Prefab_Audio_MoveBomb);

        //拡大
        for (float t = 0.0f; t < _MoveBombNeedSeconds; t += Time.deltaTime)
        {
            float e = t / _MoveBombNeedSeconds;
            b = Vector3.Lerp(Vector3.zero, Scale, e);
            if (target) target.SpriteObj.transform.localScale = Vector3.Lerp(b, Scale, e);
            yield return null;
        }


        if (target) target.SpriteObj.transform.localScale = Scale;
        if (target) target._isMoving = false;
        target.transform.SetParent(filed, false);
        yield return null;
    }
}
