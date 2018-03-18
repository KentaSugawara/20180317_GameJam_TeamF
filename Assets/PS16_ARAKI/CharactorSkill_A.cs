using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorSkill_A : SkillSuperClass
{
    [SerializeField]
    private GameObject playerArea;
    [SerializeField]
    private float skillMag;//magnification

    public override bool Use()
    {
        if (true)
        {
            playerArea.transform.localScale *= skillMag;
            StartTimer();
            return true;
        }
        return false;
    }
}
