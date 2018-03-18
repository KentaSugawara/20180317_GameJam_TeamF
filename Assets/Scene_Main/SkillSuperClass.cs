using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSuperClass : MonoBehaviour {
    [SerializeField]
<<<<<<< HEAD
    protected float _UseDelaySeconds;
    public float UseDelaySeconds
    {
        get { return _UseDelaySeconds; }
    }
=======
    private float _UseDelaySeconds;
    
>>>>>>> fed9d0455b05f16d5205955b9a2f0cb262d4fe27

    protected bool _canUse = true;
    public bool canUse
    {
        get { return _canUse; }
    }

    protected float _ElapsedDelaySconds = 0.0f;
    public float ElapsedDelaySconds
    {
        get { return _ElapsedDelaySconds; }
    }

    [SerializeField]
    protected bool _isPlayer1;
    public bool isPlayer1
    {
        get { return _isPlayer1; }
        set { _isPlayer1 = value; }
    }

<<<<<<< HEAD
    public virtual bool Use()
    {
        return false;
    }
=======
    public virtual bool Use() { return false; }
>>>>>>> fed9d0455b05f16d5205955b9a2f0cb262d4fe27

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
        _ElapsedDelaySconds = 0.0f;
        for (float t = 0.0f; t < Seconds; t += Time.deltaTime)
        {
            _ElapsedDelaySconds = t;
            yield return null;
        }
        _ElapsedDelaySconds = 1.1f;
        endcallback();
        _canUse = true;
    }
}