using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro 사용 위함
using UnityEngine.SceneManagement; // Scene 사용 위함

public class GameManager : MonoBehaviour
{   
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;

    // GameOver Panel
    [SerializeField]
    private GameObject gameOverPanel;

    private int coin = 0;

    // public이여도 인스펙터에서 확인 불가능
    [HideInInspector]
    // 게임 끝난는지 확인하는 변수
    public bool isGameOVer = false;

    // Awake 메소드 -> start보다 한단계 먼저 불러짐
    void Awake() {
        // 초기 상태의 경우
        if (instance == null) {
            // instance에 GameManager 넣어주기
            instance = this;
        }
    }

    // 코인 수 증가 처리
    public void IncreaseCoin() {
        coin++;
        
        // UI 반영
        text.SetText(coin.ToString());

        if (coin % 30 == 0) {
            // player 객체 불러오기
            Player player = FindObjectOfType<Player>();
            // 무기 업그레이드
            if (player != null) {
                player.Upgrade();
            }
        }
    }

    // 게임 종료
    public void SetGameOver() {
        // 게임 종료 처리
        isGameOVer = true;
        
        // ememySpawner 찾기
        EmemySpawner enemySpawner = FindObjectOfType<EmemySpawner>();
        
        // 찾았으면
        if (enemySpawner != null) {
            // 생성 종료
            enemySpawner.StopEmemyRoutine();
        }

        // 1초 후 게임 종료 패널 활성화
        Invoke("ShowGameOverPanel", 1f);
    }

    // 게임 종료 패널 활성화
    void ShowGameOverPanel() {
        gameOverPanel.SetActive(true);
    }

    // 다시 시작
    public void PlayAgain() {
        SceneManager.LoadScene("SampleScene");
    }
}
