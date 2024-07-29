using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{   
    [SerializeField]
    private float moveSpeed = 10f;

    // 처음 호출될 때 실행
    void Start() {
        // 1초뒤에 gameObject 삭제
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;     
    }
}