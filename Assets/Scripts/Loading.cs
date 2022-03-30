using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField]
    Image LoadingBar;
    int nowStage;
    string whatScene;
    GameObject LoadingManager, txt;

    // Start is called before the first frame update
    void Start()
    {
        LoadingManager = GameObject.Find("lts");
        txt = GameObject.Find("Canvas/LoadingText");
        nowStage = LoadingManager.GetComponent<LoadingToStage>().startStageNum;
        if (nowStage == 1) {
            whatScene = "Stage1";
            txt.GetComponent<Text>().text = "우주 정거장 가는 중...";
        }
        else if (nowStage == 2) {
            whatScene = "Stage2";
            txt.GetComponent<Text>().text = "적의 침공에 맞서 싸우는  중...";
        }
        else if (nowStage == 3) {
            whatScene = "BossStage";
            txt.GetComponent<Text>().text = "동왕성을 향해 가는 중...";
        }
        Destroy(LoadingManager);
        LoadingBar.fillAmount = 0;
        StartCoroutine(LoadAsyncScene());
    }
    private void Update()
    {
        
    }
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("Loading");
    }

    IEnumerator LoadAsyncScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(whatScene);
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
