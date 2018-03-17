using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour {
    int bombMaxValue;
    //爆弾の配列(ポジションが被らないように)
    GameObject[] bombs;
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
    //爆弾の出るタイム
    public float p1Time;
    public float p2Time;
    //タイマー
    float p1CountTimer=0;
    float p2CountTimer=0;
    //爆弾のprefab
    [SerializeField]
    GameObject bombPre;
    private void Start()
    {
        bombMaxValue =  stageWidth/bombWidth;
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
            //timerが規定のタイムを超えていたら爆弾をポップ
            if (p1CountTimer>=p1Time)
            {
                BombPopUp(p1topLeft);
                p1CountTimer = 0;
            }
            if (p2CountTimer>=p2Time)
            {
                BombPopUp(p2topLeft);
                p2CountTimer = 0;
            }
            yield return null;
        }
    }
    //popに成功したらtrueを返す
    bool BombPopUp(Vector3 startVec)
    {
        int num = GetPopSpaceNum();
        if (num==NONE)
        {
            return false;
        }
        else
        {
            Vector3 popVec = startVec;
            popVec.x += bombWidth * num;
            BombPop(popVec, num);
            return true;
        }
      
    }
    //0~bombmaxvalueまでのポップ出来るランダムな数字を返す。無い場合は-1を返す
    int GetPopSpaceNum()
    {
        List<int> bombNumbers=new List<int>();
        int n=0;
        foreach (var i in bombs)
        {
            if (i==null)
            {
                bombNumbers.Add(n);
            }
            n++;
        }
        int num=Random.Range(0,bombNumbers.Count-1);
        if (bombNumbers.Count==0)
        {
            return NONE;
        }
        else
        {
            return bombNumbers[num];
        }
        
    }
    //引数の場所に爆弾をinstansiateし、引数の番号に入れる
    void BombPop(Vector3 _pos,int bombArrayNumber)
    {
        var b=Instantiate(bombPre,_pos,Quaternion.identity);
        bombs[bombArrayNumber]=b;
    }
}
