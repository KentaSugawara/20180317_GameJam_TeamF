using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterSelect : MonoBehaviour
{
    [SerializeField]CharacterSelectManager characterSelectManager;
    [SerializeField] string INPUT_NAME_MOVE_H;
    [SerializeField] string INPUT_ENTER;
    [SerializeField] string INPUT_BACK;
    [SerializeField] GameObject selectFlame;
    [SerializeField] Image CharaImgPanel;
    [SerializeField] GameObject selectedImage;
    [SerializeField] Text _text; 
    int selectCharaNumber = 0;
    float selectDelay = 0.2f;
    bool charaSelectEnterFlag = false;
    public int SelectCharaNumber
    {
        get
        {
            return selectCharaNumber;
        }
    }
    // Use this for initialization
    void Start()
    {
        StartCoroutine(CharaSelect());
        StartCoroutine(CharaSelectMove());
        StartCoroutine(InputCheck());
    }
    void ChageTrigger()
    {
        CharaImgPanel.sprite = characterSelectManager.charaSprites[selectCharaNumber];
        _text.text =characterSelectManager.skillNames[selectCharaNumber];
    }
    IEnumerator CharaSelectMove()
    {
        while (true)
        {
            var target = characterSelectManager.charaFlames[selectCharaNumber].transform.position;
            if (Vector3.Distance(selectFlame.transform.position, target) > 1.0f)
            {
                var diff = target - selectFlame.transform.position;
                diff *= 0.2f;
                selectFlame.transform.position += diff;
            }
            yield return null;
        }
    }
    IEnumerator InputCheck()
    {
        while (true)
        {
            if (Input.GetButtonDown(INPUT_ENTER))
            {
                selectedImage.SetActive(true);
                charaSelectEnterFlag = true;
            }
            if (Input.GetButtonDown(INPUT_BACK))
            {
                selectedImage.SetActive(false);
                charaSelectEnterFlag = false;
            }
            yield return null;
        }
    }
    IEnumerator CharaSelect()
    {
        while (true)
        {
            if (!charaSelectEnterFlag)
            {
                var h = Input.GetAxis(INPUT_NAME_MOVE_H);
                if (h > 0.5f && !(selectCharaNumber >= characterSelectManager.charaFlames.Length - 1))
                {
                    selectCharaNumber++;
                    ChageTrigger();
                    yield return new WaitForSeconds(selectDelay);
                }
                else if (h < -0.5f && !(selectCharaNumber <= 0))
                {
                    selectCharaNumber--;
                    ChageTrigger();
                    yield return new WaitForSeconds(selectDelay);
                }
            }
            yield return null;
        }
    }
}
