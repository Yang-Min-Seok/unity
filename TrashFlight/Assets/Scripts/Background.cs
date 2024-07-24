using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // private 선언 -> 다른 클래스에서 사용 불가능
    private float moveSpeed = 3f; // 실수 선언 f붙여줌

    // Update is called once per frame
    void Update() // 컴퓨터 성능에 따라 불리는 횟수가 달라짐(Frame Per Second)
    {   
        // Time.deltaTime -> 컴퓨터 성능에 따른 실행 횟수 차이 방지
        transform.position += Vector3.down * moveSpeed * Time.deltaTime; 
        if (transform.position.y < -10) {
            // y값을 -10에서 10으로 옮기기 => 10 * 2
            transform.position += new Vector3(0, 10 * 2f, 0);
            
        }
    }
}
