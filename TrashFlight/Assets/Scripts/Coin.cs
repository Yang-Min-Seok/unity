using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{   
    private float minY = -7f;
    
    // Start is called before the first frame update
    void Start()
    {   
        // 만들어 졌을 때 위로 점프시킴
        Jump();
    }

    void Jump() {
        // RigidBody 가져오기
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        
        // 랜덤으로 점프 규모 정하기
        float randomJumpForce = Random.Range(4f, 8f); // 4.0 ~ 8.0 사이의 실수 구하기
        
        // 점프 규모를 랜덤으로 정하기 (방향 = 위)
        Vector2 jumpVelocity = Vector2.up * randomJumpForce;

        // x값도 적용시키기
        jumpVelocity.x = Random.Range(-2f, 2f);

        // 코인 점프시키기
        rigidBody.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
        // y의 값이 minY보다 작아지면
        if (transform.position.y < minY) {
            Destroy(gameObject);
        }
    }
}
