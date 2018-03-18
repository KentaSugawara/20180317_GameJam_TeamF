using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSuperClass : MonoBehaviour {
    [SerializeField]
    private float _UseDelaySeconds;
    

    protected bool _canUse;
    public bool canUse
    {
        get { return _canUse; }
    }

    protected float _RemainingDelaySconds;
    public float RemainingDelaySconds
    {
        get { return _RemainingDelaySconds; }
        set { _RemainingDelaySconds = value; }
    }

    [SerializeField]
    protected bool _isPlayer1;
    public bool isPlayer1
    {
        get { return _isPlayer1; }
        set { _isPlayer1 = value; }
    }

    public virtual bool Use() { return false; }

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
        yield return new WaitForSeconds(Seconds);
        endcallback();
        _canUse = true;
    }
}