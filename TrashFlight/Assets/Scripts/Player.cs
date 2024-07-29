using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    // 값을 넣을 수 있게 해줌 (유니티에서)
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private Transform shootTransform;

    // Update is called once per frame
    void Update()
    {   

        // // 키보드로부터 입력받은 좌우값
        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        
        // // 키보드로부터 입력받은 상하값
        // // float vertialInput = Input.GetAxisRaw("Vertical");

        // // 움직이기
        // Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);
        // transform.position += moveTo * moveSpeed * Time.deltaTime;

        // // moveTo -> 좌우 이동만 허용
        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        // // 키보드로부터 받은 입력값이 좌이동이면
        // if (Input.GetKey(KeyCode.LeftArrow)) {
        //     // 포지션을 -= moveTo로 변환
        //     transform.position -= moveTo;
        // } else if (Input.GetKey(KeyCode.RightArrow)) { // 우이동이면
        //     // 포지션을 += moveTo로 변환
        //     transform.position += moveTo;
        // }

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
        Instantiate(weapon, shootTransform.position, Quaternion.identity);
    }
}
