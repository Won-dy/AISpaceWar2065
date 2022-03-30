using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager1 : MonoBehaviour
{
    public Text currentScoreUI; //현재 점수 Text오브젝트
    private int currentScore1; // 
    public Text bestScoreUI; // 최고점수 UI Text
    private int bestScore1;

    public static ScoreManager1 Instance = null; // 싱글톤 객체
    public void Awake()
    {
        if (Instance == null)// 싱글톤 객체 값이 없으면 자기자신을 할당
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        bestScore1 = PlayerPrefs.GetInt("Best Score1", 0);
        bestScoreUI.text = "최고 점수 : " + bestScore1;
    }
    public int Score1 //프로퍼티
    {
        get
        {
            return currentScore1;
        }
        set
        {
            currentScore1 = value;
            currentScoreUI.text = "현재 점수 : " + currentScore1;
            if (currentScore1 > bestScore1)
            {
                bestScore1 = currentScore1;
                bestScoreUI.text = "최고 점수 : " + bestScore1;
                PlayerPrefs.SetInt("Best Score1", bestScore1);
            }
        }
    }
    public void SetScore1(int value)
    {
        currentScore1 = value;
        currentScoreUI.text = "현재 점수 : " + currentScore1;
        if (currentScore1 > bestScore1)
        {
            bestScore1 = currentScore1;
            bestScoreUI.text = "최고 점수 : " + bestScore1;
            PlayerPrefs.SetInt("Best Score1", bestScore1);
        }

    }
    public int GetScore1()
    {
        return currentScore1;
    }
}
