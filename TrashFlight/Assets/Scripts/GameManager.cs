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

    // 코인 수 증가
    public void IncreaseCoin() {
        coin++;
        text.SetText(coin.ToString());
    }
}
