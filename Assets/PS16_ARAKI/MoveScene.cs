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
    private bool gameFirstScene;
    //[SerializeField]
    private Image img;
    [SerializeField]
    private float feedTime = 1.5f;
    private float timer = 0;
    private bool check;

    private void Awake()
    {
        check = !gameFirstScene;
        img = GetComponent<Image>();
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
        AsyncOperation async = SceneManager.LoadSceneAsync(nextSceneName);
        async.allowSceneActivation = false;
        for (timer = 0; timer < feedTime; timer += Time.deltaTime)
        {
            img.color = new Color(0, 0, 0, timer / feedTime);
            yield return null;
        }
        for (timer = 0; timer < 100; timer += Time.deltaTime)
            if (Input.GetKey(KeyCode.Space) || timer > 10 || async.isDone == true)
            {
                async.allowSceneActivation = true;
                break;
            }
        async.allowSceneActivation = true;
    }
    private IEnumerator OffMoveScene()
    {
        img.color = new Color(0, 0, 0, 1);
        check = true;
        yield return new WaitForSeconds(0.5f);
        for (timer = 0; timer < feedTime; timer += Time.deltaTime)
        {
            img.color = new Color(0, 0, 0, 1.0f - timer / feedTime);
            yield return null;
        }
        check = false;
    }

    //   private void Update()
    //   {
    //       if (check == false)
    //       {
    //           timer += Time.deltaTime;
    //           if (timer >= 2.0f) NextScene();
    //       }
    //   }
}
