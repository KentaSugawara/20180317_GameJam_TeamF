using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    private float feedTime = 1.5f;
    [SerializeField, TooltipAttribute("最初にフェードアウトが必要ない場合はチェック")]
    private bool gameFirstScene;

    private Image img;
    private float timer = 0;
    private bool check;

    private void Awake()
    {
        check = !gameFirstScene;
        img = transform.GetChild(0).GetComponent<Image>();
        if (gameFirstScene != true) StartCoroutine(OffMoveScene());
        else
        {
            img.color = new Color(0, 0, 0, 0);
        }
    }
    public void NextScene()
    {
        check = true;
        StartCoroutine(OnMoveScene());
    }
    private IEnumerator OnMoveScene()
    {
        img.color = new Color(0, 0, 0, 0);
        AsyncOperation async = SceneManager.LoadSceneAsync(nextSceneName);
        async.allowSceneActivation = false;
        for (timer = 0; timer < feedTime; timer += Time.deltaTime)
        {
            img.color = new Color(0, 0, 0, timer / feedTime);
            yield return null;
        }
        img.color = new Color(0, 0, 0, 1);
        for (timer = 0; timer < 60; timer += Time.deltaTime)
        {
            if (timer >= 60 || async.isDone == true)
            {
                async.allowSceneActivation = true;
                break;
            }
            yield return null;
        }
    }
    private IEnumerator OffMoveScene()
    {
        check = true;
        img.color = new Color(0, 0, 0, 1);
        yield return new WaitForSeconds(0.5f);
        for (timer = 0; timer < feedTime; timer += Time.deltaTime)
        {
            img.color = new Color(0, 0, 0, 1.0f - timer / feedTime);
            yield return null;
        }
        img.color = new Color(0, 0, 0, 0);
        check = false;
    }
}
