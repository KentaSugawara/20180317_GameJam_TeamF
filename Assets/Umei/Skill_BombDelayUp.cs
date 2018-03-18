using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_BombDelayUp : SkillSuperClass
{
    //爆弾のスポーンディレイに掛ける値
    public float SpawnDelayMultiplyValue;
    [SerializeField]
    BombManager bManager;
    [SerializeField]
    CharacterArmy PlayerArmy;
    //効果時間
    [SerializeField]
    float effectTime;
    public override bool Use()
    {
        if (!bManager) return false;

        return true;
    }
    IEnumerator BombDelayChange()
    {
        //前のディレイタイムに戻すための値
        float PreRatio = 1.0f / SpawnDelayMultiplyValue;
        //自分がp1だった場合p2の時間を変える,p2だった場合はp1の時間を変える
        if (PlayerArmy == CharacterArmy.P1) bManager.p2State.SpawnDelay *= SpawnDelayMultiplyValue;
        if (PlayerArmy == CharacterArmy.P2) bManager.p1State.SpawnDelay *= SpawnDelayMultiplyValue;
        yield return new WaitForSeconds(effectTime);
        if (PlayerArmy == CharacterArmy.P1) bManager.p2State.SpawnDelay *= PreRatio;
        if (PlayerArmy == CharacterArmy.P2) bManager.p1State.SpawnDelay *= PreRatio;
    }
}
