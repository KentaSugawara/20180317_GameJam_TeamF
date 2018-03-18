﻿using System.Collections;
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

    public virtual bool Use()
    {


        return false;
    }

    public void StartTimer()
    {
        if (_canUse)
        {
            _canUse = false;
            StartCoroutine(Routine_Timer(_UseDelaySeconds));
        }
    }

    protected IEnumerator Routine_Timer(float Seconds)
    {
        yield return new WaitForSeconds(Seconds);
        _canUse = true;
    }
}