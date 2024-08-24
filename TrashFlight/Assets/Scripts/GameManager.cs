using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro 사용 위함

public class GameManager : MonoBehaviour
{   
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;
    private int coin = 0;

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

        if (coin % 10 == 0) {
            // player 객체 불러오기
            Player player = FindObjectOfType<Player>();
            // 무기 업그레이드
            if (player != null) {
                player.Upgrade();
            }
        }

    }
}
