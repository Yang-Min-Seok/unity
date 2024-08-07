using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    private float minY = -7f;
    
    [SerializeField]
    private float hp = 1f;

    // 외부에서 메소드 사용 가능 (public)
    public void SetMoveSpeed(float moveSpeed) {
        this.moveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {   
        // 아래로 떨어뜨려주기
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        
        // y의 값이 minY보다 작아지면
        if (transform.position.y < minY) {
            Destroy(gameObject);
        }
    }

    // 트리거가 체크된 객체의 충돌이 감지되었을 때
    private void OnTriggerEnter2D(Collider2D other) {
        // Weapon 태그 값을 갖는 객체와 충돌하면
        if (other.gameObject.tag == "Weapon") {
            // 충돌한 컴포넌트를 얻어오기
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            // 체력 깎아주기
            hp -= weapon.damage;
            // hp가 0이하로 떨어지면
            if (hp <= 0) {
                // ememy없애주기
                Destroy(gameObject);
            }
            // 미사일 없애주기
            Destroy(other.gameObject);
        }   
    }
}
