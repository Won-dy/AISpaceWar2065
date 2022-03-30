using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text currentScoreUI; //현재 점수 Text오브젝트
    private int currentScore; // 
    public Text bestScoreUI; // 최고점수 UI Text
    private int bestScore;

    public static ScoreManager Instance = null; // 싱글톤 객체

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
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "최고 점수 : " + bestScore;
    }

    public int Score //프로퍼티
    {
        get {
            return currentScore;
        }
        set {
            currentScore = value;
            currentScoreUI.text = "현재 점수 : " + currentScore;
            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bestScoreUI.text = "최고 점수 : " + bestScore;
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }

    public void SetScore(int value)
    {
        currentScore = value;
        currentScoreUI.text = "현재 점수 : " + currentScore;
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            bestScoreUI.text = "최고 점수 : " + bestScore;
            PlayerPrefs.SetInt("Best Score", bestScore);
        }

    }
    public int GetScore()
    {
        return currentScore;
    }
}
