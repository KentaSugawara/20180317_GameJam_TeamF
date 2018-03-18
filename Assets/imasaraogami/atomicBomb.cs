using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atomicBomb : SkillSuperClass {
    [SerializeField]
    public float range = 2;

    [SerializeField]
    private test_FieldManager _FieldManager;

    public override bool Use()
    {
        if (_canUse)
        {
            StartTimer(dummy);
            StartCoroutine(skill());
            return true;
        }
        else return false;
    }

    private void dummy() { }

    IEnumerator skill()
    {

        //var fieldmanager = GetComponent<test_FieldManager>();
        if (_isPlayer1)
        {
            _FieldManager._BombScaleToField2 = range;
        }
        else
        {
            _FieldManager._BombScaleToField1 = range;
        }
        yield return null;
    }

}
