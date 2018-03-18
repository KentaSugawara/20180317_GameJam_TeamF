using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorSkill_A : SkillSuperClass
{
    [SerializeField]
    private GameObject playerArea;
    [SerializeField]
    private float skillMag;//magnification
    [SerializeField]
    private float skillTimer;


    public override bool Use()
    {
        if (_canUse==true)
        {
            playerArea.transform.localScale *= skillMag;
            StartTimer(EndSkill);
            return true;
        }
        return false;
    }
    private IEnumerator Routine_endSkill(){
        yield return new WaitForSeconds(skillTimer);
        playerArea.transform.localScale /= skillMag;
    }
    public void EndSkill()
    {
        playerArea.transform.localScale /= skillMag;
    }
}
