using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atomicBomb : SkillSuperClass {
    [SerializeField]
    public float range = 2;

    public override bool Use()
    {
        if (_canUse)
        {
            StartCoroutine(Skill());
            return true;
        }
        else return false;
    }

    IEnumerator Skill()
    {
        var fieldmanager = GetComponent<test_FieldManager>();
        if (_isPlayer1)
        {
            fieldmanager._BombScaleToField2 = range;
        }
        else
        {
            fieldmanager._BombScaleToField1 = range;
        }
        yield return null;
    }

}
