using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    // 값을 넣을 수 있게 해줌 (유니티에서)
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject[] weapons;
    private int weaponIndex = 0;

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private float shootInterval = 0.05f; // 슈팅 간격 설정
    private float lastShotTime = 0f; // 마지막으로 쏜 시각

    // Update is called once per frame
    void Update()
    {   

        // 마우스 좌표 값 가져오기
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // 범위 못벗어나게 처리
        // Mathf.Clamp(value, 최솟값, 최댓값)
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f);

        // 움직이기
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);

        // 무기 쏘기
        Shoot();
    }

    // 무기 쏘기
    void Shoot() {
        // 시작한 시간 - 마지막 쏜 시각이 간격보다 커지면
        if (Time.time - lastShotTime > shootInterval) {
            // 발사
            Instantiate(weapons[weaponIndex], shootTransform.position, Quaternion.identity);
            // 마지막 쏜 시각 업데이트
            lastShotTime = Time.time;
        }
    }

    // 플레이어 충돌 처리
    private void OnTriggerEnter2D(Collider2D other) {
        // 충돌 대상이 Ememy이거나 Boss이면
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss") {
            Debug.Log("Game Over");
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Coin") { // 충돌 대상이 코인인 경우
            GameManager.instance.IncreaseCoin(); // 코인 올려주기
            Destroy(other.gameObject);
        }
    }

    // 무기 업그레이드
    public void Upgrade() {
        weaponIndex++;
        // 방어코드
        if (weaponIndex >= weapons.Length) {
            weaponIndex = weapons.Length - 1;
        }
    }
}
