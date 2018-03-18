using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    int bombMaxValue;
    //爆弾の配列(ポジションが被らないように)
    GameObject[] bombs;
    enum CharacterArmy
    {
        P1, P2
    }
    const int NONE = -1;
    //爆弾の横幅
    public int bombWidth;
    //ステージの横幅
    public int stageWidth;
    //p1ステージの左上
    [SerializeField]
    Vector3 p1topLeft;
    //p2ステージの左上
    [SerializeField]
    Vector3 p2topLeft;
    [SerializeField]
    GameObject Stage1;
    [SerializeField]
    GameObject Stage2;
    //爆弾の出るタイム
    public float p1Time;
    public float p2Time;
    public float popMaxHeight = 10.0f;
    CharacterArmy preBombArmy;
    //タイマー
    float p1CountTimer = 0;
    float p2CountTimer = 0;
    //爆弾のprefab
    [SerializeField]
    GameObject bombPre1;
    [SerializeField]
    GameObject bombPre2;

    bool P1CanPop()
    {
        return (p1CountTimer >= p1State.SpawnDelay);
    }
    bool P2CanPop()
    {
        return (p2CountTimer >= p2State.SpawnDelay);
    }
    public BombState p1State;
    public BombState p2State;

    private void Start()
    {
        bombMaxValue = stageWidth / bombWidth;
        bombs = new GameObject[bombMaxValue];
        //カメラからステージの左上を求めるz座標だけはステージ座標
        StartCoroutine(BombUpdate());
    }
    IEnumerator BombUpdate()
    {
        while (true)
        {
            //timerのカウントを進める
            p1CountTimer += Time.deltaTime;
            p2CountTimer += Time.deltaTime;

            //timerが規定のタイムを超えていたら爆弾をポップ。どっちもpopする場合は優先度を変える。
            if (P1CanPop() && P2CanPop() && preBombArmy == CharacterArmy.P1)
            {
                if (P2CanPop())
                {
                    BombPopUp(CharacterArmy.P2);
                    preBombArmy = CharacterArmy.P2;
                    p2CountTimer = 0;
                }
                if (P1CanPop())
                {
                    BombPopUp(CharacterArmy.P1);
                    preBombArmy = CharacterArmy.P1;
                    p1CountTimer = 0;
                }
            }
            else
            {
                if (P1CanPop())
                {
                    BombPopUp(CharacterArmy.P1);
                    preBombArmy = CharacterArmy.P1;
                    p1CountTimer = 0;
                }
                if (P2CanPop())
                {
                    BombPopUp(CharacterArmy.P2);
                    preBombArmy = CharacterArmy.P2;
                    p2CountTimer = 0;
                }
                //timerが規定のタイムを超えていたら爆弾をポップ
                if (p1CountTimer >= p1Time)
                {
                    BombPopUp(CharacterArmy.P1);
                    p1CountTimer = 0;
                }
                if (p2CountTimer >= p2Time)
                {
                    BombPopUp(CharacterArmy.P2);
                    p2CountTimer = 0;
                }
                yield return null;
            }
        }
    }
    //popに成功したらtrueを返す
    bool BombPopUp(CharacterArmy _attr)
    {
        int num = GetPopSpaceNum();
        if (num == NONE)
        {
            return false;
        }
        else
        {
            Vector3 startVec = Vector3.zero;
            if (_attr == CharacterArmy.P2)
            {
                startVec = p2topLeft;
            }
            if (_attr == CharacterArmy.P1)
            {
                startVec = p1topLeft;
            }
            Vector3 popVec = startVec;
            popVec.x += bombWidth * num;
            popVec.y -= Random.Range(0, popMaxHeight);
            BombPop(popVec, num, _attr);
            return true;
        }

    }
    //0~bombmaxvalueまでのポップ出来るランダムな数字を返す。無い場合は-1を返す
    int GetPopSpaceNum()
    {
        List<int> bombNumbers = new List<int>();
        int n = 0;
        foreach (var i in bombs)
        {
            if (i == null)
            {
                bombNumbers.Add(n);
            }
            n++;
        }
        int num = Random.Range(0, bombNumbers.Count - 1);
        if (bombNumbers.Count == 0)
        {
            return NONE;
        }
        else
        {
            return bombNumbers[num];
        }

    }
    //引数の場所に爆弾をinstansiateし、引数の番号に入れる
    void BombPop(Vector3 _pos, int bombArrayNumber, CharacterArmy _attr)
    {
        Transform p = null;
        if (_attr == CharacterArmy.P1)
        {
            p = Stage1.transform;
            var b = Instantiate(bombPre1, _pos, Quaternion.identity, p);
            bombs[bombArrayNumber] = b;
        }
        if (_attr == CharacterArmy.P2)
        {
            p = Stage2.transform;
            var b = Instantiate(bombPre2, _pos, Quaternion.identity, p);
            bombs[bombArrayNumber] = b;
        }

    }
}

public class BombState
{
    public float SpawnDelay;
    public float ExprosionRange;
}
