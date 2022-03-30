using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading2 : MonoBehaviour
{
    [SerializeField]
    Image LoadingBar;

    // Start is called before the first frame update
    void Start()
    {
        LoadingBar.fillAmount = 0;
        StartCoroutine(LoadAsyncScene());
    }
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("Loading2");
    }

    IEnumerator LoadAsyncScene()
    {
        yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync("Stage2");
        op.allowSceneActivation = false;

        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;

            timer += Time.deltaTime;

            if (op.progress >= 0.9f)
            {
                LoadingBar.fillAmount = Mathf.Lerp(LoadingBar.fillAmount, 1f, timer);

                if (LoadingBar.fillAmount == 1.0f)
                    op.allowSceneActivation = true;
            }
            else
            {
                LoadingBar.fillAmount = Mathf.Lerp(LoadingBar.fillAmount, op.progress, timer);
                if (LoadingBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
        }
    }
}
