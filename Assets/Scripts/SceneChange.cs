using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ChangeIntroScene()
    {
        //SoundManager.instance.BtnClickSound();
        SceneManager.LoadScene("Intro");
    }
    public void ChangeStage1Scene()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void ChangeStage2Scene()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void ChangeBossStageScene()
    {
        SceneManager.LoadScene("BossStage");
    }
    public void ChangeEndingScene()
    {
        SceneManager.LoadScene("Ending_Complete");
    }
    public void ChangeDieEndingScene()
    {
        SceneManager.LoadScene("Ending_Die");
    }
    public void ChangeLoadingScene()
    {
        SceneManager.LoadScene("Loading");
    }
    public void ChangeHowToScene()
    {
        SceneManager.LoadScene("HowTo");
    }
    public void RetryStage()
    {
        if (StageManager.stageNum == 1)
            SceneManager.LoadScene("Stage1");
        else if (StageManager.stageNum == 2)
            SceneManager.LoadScene("Stage2");
        else if (StageManager.stageNum == 3)
            SceneManager.LoadScene("BossStage");
    }
}
