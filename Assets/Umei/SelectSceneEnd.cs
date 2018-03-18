using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSceneEnd : MonoBehaviour {
    [SerializeField]
    CharacterSelectManager characterSelectManager;
    void GoBattleScene()
    {
        CharacterTypeData.p1CharaNumber = (CharaData)characterSelectManager.p1.SelectCharaNumber;
        CharacterTypeData.p2CharaNumber = (CharaData)characterSelectManager.p2.SelectCharaNumber;
        //シーン移行処理
    }
}
