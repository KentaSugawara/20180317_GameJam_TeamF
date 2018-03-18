using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoutine : MonoBehaviour {
    [SerializeField]
    private Main_StartEffect _StartEffect;

    [SerializeField]
    private int _CharaIndex1;

    [SerializeField]
    private List<GameObject> _Chara1InstanceList = new List<GameObject>();

    [SerializeField]
    private int _CharaIndex2;

    [SerializeField]
    private List<GameObject> _Chara2InstanceList = new List<GameObject>();

    private test_Character _Player1_TargetCharacter;
    public test_Character Player1_TargetCharacter
    {
        get { return _Player1_TargetCharacter; }
    }
    private test_Character _Player2_TargetCharacter;
    public test_Character Player2_TargetCharacter
    {
        get { return _Player2_TargetCharacter; }
    }

    [SerializeField]
    private GameObject _BombManagerObj;

    [SerializeField]
    private GameTimerText _Timer;

    [SerializeField]
    private SkillViewer _SkillViewer1;

    [SerializeField]
    private SkillViewer _SkillViewer2;

    private void Awake()
    {
        foreach (var chara in _Chara1InstanceList)
        {
            chara.SetActive(false);
        }
        _Chara1InstanceList[_CharaIndex1].SetActive(true);
        _Player1_TargetCharacter = _Chara1InstanceList[_CharaIndex1].GetComponent<test_Character>();

        foreach (var chara in _Chara2InstanceList)
        {
            chara.SetActive(false);
        }
        _Chara2InstanceList[_CharaIndex2].SetActive(true);
        _Player2_TargetCharacter = _Chara2InstanceList[_CharaIndex2].GetComponent<test_Character>();
    }

    private void Start()
    {
        StartCoroutine(Routine_Main());
    }

    private IEnumerator Routine_Main()
    {

        //スタート待機
        yield return StartCoroutine(_StartEffect.Routine_Effect());

        //スタート処理
        {
            //キャラの操作を開始
            _Player1_TargetCharacter.StartRoutine();
            _Player2_TargetCharacter.StartRoutine();

            //BombManagerをアクティブに
            _BombManagerObj.SetActive(true);

            //タイマー開始
            _Timer.StartMainRoutine();

            _SkillViewer1.Init(_Player1_TargetCharacter.Skill);
            _SkillViewer2.Init(_Player2_TargetCharacter.Skill);
        }

    }
}
