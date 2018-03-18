using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_BombDelayUp : SkillSuperClass
{
    //爆弾のスポーンディレイに掛ける値
    public float SpawnDelayMultiplyValue;
    [SerializeField]
    BombManager bManager;
    //効果時間
    [SerializeField]
    float effectTime;
    public override bool Use()
    {
        if (!bManager) return false;
        StartCoroutine(BombDelayChange());
        return true;
    }
    IEnumerator BombDelayChange()
    {
        //前のディレイとの差（効果が終わったら足す）
        float sub = 0;
        //自分がp1だった場合p2の時間を変える,p2だった場合はp1の時間を変える
        if (isPlayer1)
        {
            var preDelay = bManager.p2State.SpawnDelay;
            bManager.p2State.SpawnDelay *= SpawnDelayMultiplyValue;
            sub = preDelay - bManager.p2State.SpawnDelay;
        }
        else
        {
            var preDelay = bManager.p1State.SpawnDelay;
            bManager.p1State.SpawnDelay *= SpawnDelayMultiplyValue;
            sub = preDelay - bManager.p1State.SpawnDelay;
        }
        yield return new WaitForSeconds(effectTime);
        //効果終了後の処理
        if (isPlayer1)
        {
            bManager.p2State.SpawnDelay += sub;
        }
        else
        {
            bManager.p1State.SpawnDelay += sub;
        }
    }
}
