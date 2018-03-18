using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSceneEnd : MonoBehaviour {
    [SerializeField]
    CharacterSelectManager characterSelectManager;
    [SerializeField]
    MoveScene moveScene;
    bool endFlag = false;
    private void Update()
    {
        if (characterSelectManager.p1.CharaSelectEnterFlag && characterSelectManager.p2.CharaSelectEnterFlag&&!endFlag)
        {
            GoBattleScene();
            endFlag = true;
        }
    }

    void GoBattleScene()
    {
        CharacterTypeData.p1CharaNumber = (CharaData)characterSelectManager.p1.SelectCharaNumber;
        CharacterTypeData.p2CharaNumber = (CharaData)characterSelectManager.p2.SelectCharaNumber;
        //シーン移行処理
        Debug.Log("end");
        moveScene.NextScene();
    }
}
