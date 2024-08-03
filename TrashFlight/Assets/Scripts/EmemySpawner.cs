using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemySpawner : MonoBehaviour
{   
    // 적 저장
    [SerializeField]
    private GameObject[] ememies;

    // x좌표 저장 (5개의 적의 시작 x좌표)
    private float[] arrPosX = {-2.2f, -1.1f, 0f, 1.1f, 2.2f};

    // Start is called before the first frame update
    void Start()
    {   
        // arrPosX에서 posX를 하나씩 꺼내 반복
        foreach(float posX in arrPosX) {
            // 랜덤으로 인덱스 생성하기
            int index = Random.Range(0, ememies.Length);
            // 생성하기
            SpawnEnemy(posX, index);
        }
    }

    // 적 생성 함수
    void SpawnEnemy(float posX, int index) {
        // 적 위치 정의
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        // 적 객체 정의
        Instantiate(ememies[index], spawnPos, Quaternion.identity);
    }
}
