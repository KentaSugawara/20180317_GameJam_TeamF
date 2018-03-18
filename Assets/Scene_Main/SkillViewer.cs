using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillViewer : MonoBehaviour {
    [SerializeField]
    private Image _Image;

    private SkillSuperClass _TargetSkill;

    public void Init(SkillSuperClass TargetSkill)
    {
        _TargetSkill = TargetSkill;
        StartCoroutine(Routine_Main());
    }

    private IEnumerator Routine_Main()
    {
        while (true)
        {
            if (_TargetSkill.canUse)
            {
                _Image.fillAmount = 1.0f;
            }
            else
            {
                _Image.fillAmount = _TargetSkill.RemainingDelaySconds / _TargetSkill.UseDelaySeconds;
            }
            yield return null;
        }
    }
}
