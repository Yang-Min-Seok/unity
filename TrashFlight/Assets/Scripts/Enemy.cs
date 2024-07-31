using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    private float minY = -7;

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
