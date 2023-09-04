using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
// 유니티 UI를 사용하기 위한 네임스페이스
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //현재 점수 UI
    public Text currentScoreUI;
    // 현재 점수
    private int currentScore;
    //최고 점수 UI
    public Text BestScoreUI;
    // 최고 점수
    private int BestScore;

    //싱글턴 객체
    public static ScoreManager Instance = null;

    //싱글턴 객체에 값이 없으면 생성된 자기 자신을 할당
    private void Awake() // 프로그램 실행시 모든 변수 및 게임상태 초기화를 위해 가장먼저 실행
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            // 3.Scoremanager 클래스의 속성에 값을 할당한다,
            currentScore++;
            // 4.화면에 현재 점수 표기하기
            currentScoreUI.text = "현재점수 : " + currentScore;
            //->만약 현재 점수가 최고 점수를 초과했다면
            if (currentScore > BestScore)
            {
                // 최고 점수 갱신
                BestScore = currentScore;
                //화면 표시
                BestScoreUI.text = "최고점수 : " + BestScore;
                //최고 점수 클라이언트 측에 저장
                PlayerPrefs.SetInt("Best Score", BestScore);
            }
        }
    }


    private void Start()
    {
        //목표: 쵝고 점수를 불러와 bestSclore 변수에 할당하고 화면에 표시
        //순서 1. 최고 점수를 불러와 bestScore에 넣어주기
        BestScore = PlayerPrefs.GetInt("Best Score", 0);
        // 2. 최고 점수를 화면에 표시하기
        BestScoreUI.text = "최고점수 : " + BestScore;
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
