using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingToStage : MonoBehaviour
{
    public int startStageNum;
    public GameObject startStageNumObject;

    // Start is called before the first frame update
    public void call()
    {
        SceneManager.LoadScene("Loading");
        DontDestroyOnLoad(startStageNumObject);
    }
}
