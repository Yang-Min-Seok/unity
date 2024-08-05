using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    private float minY = -7;

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
}
