using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSuperClass : MonoBehaviour {
    [SerializeField]
    protected float _UseDelaySeconds;
    public float UseDelaySeconds
    {
        get { return _UseDelaySeconds; }
    }

    protected bool _canUse = true;
    public bool canUse
    {
        get { return _canUse; }
    }

    protected float _ElapsedDelaySconds;
    public float ElapsedDelaySconds
    {
        get { return _ElapsedDelaySconds; }
        set { _ElapsedDelaySconds = value; }
    }

    [SerializeField]
    protected bool _isPlayer1;
    public bool isPlayer1
    {
        get { return _isPlayer1; }
        set { _isPlayer1 = value; }
    }

    public virtual bool Use()
    {


        return false;
    }

    public void StartTimer(System.Action endcallback)
    {
        if (_canUse)
        {
            _canUse = false;
            StartCoroutine(Routine_Timer(_UseDelaySeconds, endcallback));
        }
    }

    protected IEnumerator Routine_Timer(float Seconds, System.Action endcallback)
    {
        //yield return new WaitForSeconds(Seconds);
        for (float t = 0.0f;t < Seconds; t += Time.deltaTime)
        {
            _ElapsedDelaySconds = t;
            yield return null;
        }
        _ElapsedDelaySconds = Seconds;
        endcallback();
        _canUse = true;
    }
}