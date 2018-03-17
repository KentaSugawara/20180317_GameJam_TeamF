using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_FieldManager : MonoBehaviour {

    [SerializeField]
    private Transform _Field1;

    [SerializeField]
    private Transform _Field2;

    public void MoveObject(Transform target, bool ToField2)
    {
        Transform filed;
        if (ToField2)
        {
            filed = _Field2;
        }
        else
        {
            filed = _Field1;
        }

        target.SetParent(filed, false);
    }
}
