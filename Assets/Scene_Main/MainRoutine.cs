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

    [SerializeField]
    private AudioSource _BGM;

    [SerializeField]
    private LifeManager _LifeManager1;

    [SerializeField]
    private LifeManager _LifeManager2;

    private void Awake()
    {
        foreach (var chara in _Chara1InstanceList)
        {
            chara.SetActive(false);
        }
        var chara1 = CharacterTypeData.p1CharaNumber;
        if (chara1 == CharaData.type1) _CharaIndex1 = 0;
        else if (chara1 == CharaData.type2) _CharaIndex1 = 1;
        else if (chara1 == CharaData.type3) _CharaIndex1 = 2;
        _Chara1InstanceList[_CharaIndex1].SetActive(true);
        _Player1_TargetCharacter = _Chara1InstanceList[_CharaIndex1].GetComponent<test_Character>();

        foreach (var chara in _Chara2InstanceList)
        {
            chara.SetActive(false);
        }
        var chara2 = CharacterTypeData.p2CharaNumber;
        if (chara2 == CharaData.type1) _CharaIndex2 = 0;
        else if (chara2 == CharaData.type2) _CharaIndex2 = 1;
        else if (chara2 == CharaData.type3) _CharaIndex2 = 2;
        _Chara2InstanceList[_CharaIndex2].SetActive(true);
        _Player2_TargetCharacter = _Chara2InstanceList[_CharaIndex2].GetComponent<test_Character>();
    }

    private void Start()
    {
        StartCoroutine(Routine_Main());
    }

    private IEnumerator Routine_Main()
    {
        yield return new WaitForSeconds(1.5f);
        //スタート待機
        yield return StartCoroutine(_StartEffect.Routine_Effect());

        _BGM.Play();

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

        while (true)
        {
            if (_Timer.time <= 0.1f)
            {
                StartCoroutine(Routine_TimeUp());
                yield break;
            }

            if (_LifeManager1.isDead)
            {
                StartCoroutine(Routine_Win_2());
                yield break;
            }
            else if (_LifeManager2.isDead)
            {
                StartCoroutine(Routine_Win_1());
                yield break;
            }
            yield return null;
        }
    }

    [SerializeField]
    private GameObject _TimeUp;
    private IEnumerator Routine_TimeUp()
    {
        _TimeUp.SetActive(true);

        yield return new WaitForSeconds(5);
        _MoveScene.NextScene();

        //シーン遷移
        yield break;
    }

    [SerializeField]
    private GameObject _Win_1;
    private IEnumerator Routine_Win_1()
    {
        _Win_1.SetActive(true);

        yield return new WaitForSeconds(5);
        _MoveScene.NextScene();

        //シーン遷移
        yield break;
    }

    [SerializeField]
    private GameObject _Win_2;
    private IEnumerator Routine_Win_2()
    {
        _Win_2.SetActive(true);

        yield return new WaitForSeconds(5);
        _MoveScene.NextScene();

        //シーン遷移
        yield break;
    }

    [SerializeField]
    private MoveScene _MoveScene;
}
