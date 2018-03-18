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
        Transform filed;
        if (ToField2)
        {
            filed = _Field2;
            target.exprad = _BombScaleToField2;
        }
        else
        {
            filed = _Field1;
            target.exprad = _BombScaleToField1;
        }
        target.exptime2 += 1.0f;
        
        Instantiate(_Prefab_Audio_MoveBomb);
    }

    private IEnumerator Routine_MoveBomb(CreateEffect target, Transform filed)
    {
        target.transform.SetParent(filed, false);
        yield return null;
    }
}
