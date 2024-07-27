using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    // 값을 넣을 수 있게 해줌 (유니티에서)
    [SerializeField]
    private float moveSpeed; 

    // Update is called once per frame
    void Update()
    {   
        
        // 키보드로부터 입력받은 좌우값
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        
        // 키보드로부터 입력받은 상하값
        // float vertialInput = Input.GetAxisRaw("Vertical");

        // 움직이기
        Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);
        transform.position += moveTo * moveSpeed * Time.deltaTime;

    }
}
