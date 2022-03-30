using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static int stageNum;
    public static void nowScene()
    {
        if (SceneManager.GetActiveScene().name == "Stage1") stageNum = 1;
        else if (SceneManager.GetActiveScene().name == "Stage2") stageNum = 2;
        else if (SceneManager.GetActiveScene().name == "BossStage") stageNum = 3;

        if (stageNum != 0)
        {
            SceneManager.LoadScene("Ending_Die");
            DontDestroyOnLoad(GameObject.Find("StageName"));
        }
    }
}