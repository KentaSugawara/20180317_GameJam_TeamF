using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillViewer : MonoBehaviour {
    [SerializeField]
    private Image _Image;

    [SerializeField]
    private test_Character _Character;

    private void Start()
    {
        StartCoroutine(Routine_Main());
    }

    private IEnumerator Routine_Main()
    {
        while (true)
        {
            if (_Character.Skill != null)
            {
                if (_Character.Skill.canUse)
                {
                    _Image.fillAmount = 1.0f;
                }
                else
                {
                    _Image.fillAmount = _Character.Skill.ElapsedDelaySconds / _Character.Skill.UseDelaySeconds;
                }
            }
            yield return null;
        }
    }
}
