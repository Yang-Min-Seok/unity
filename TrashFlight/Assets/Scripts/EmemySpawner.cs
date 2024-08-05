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

    // 적 생성 간격
    [SerializeField]
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {   
        StartEnemyRoutine();
    }

    void StartEnemyRoutine() {
        StartCoroutine("EnemyRoutine");
    }

    // 적 무한 생성하기
    IEnumerator EnemyRoutine() {
        yield return new WaitForSeconds(3f);

        // 생성횟수
        int spawnCount = 0;
        // 생성할 적의 인덱스
        int enemyIndex = 0;

        while (true) {
            // arrPosX에서 posX를 하나씩 꺼내 반복
            foreach(float posX in arrPosX) {
                // 생성하기
                SpawnEnemy(posX, enemyIndex);
            }

            spawnCount++;

            if (spawnCount % 10 == 0) {
                enemyIndex++;
            }
            
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // 적 생성 함수
    void SpawnEnemy(float posX, int index) {
        
        // 적 위치 정의
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        // 중간중간 섞어주기
        if (Random.Range(0, 5) == 0) {
            index++;
        }


        // 인덱스 오버 방지
        if (index >= ememies.Length) {
            index = ememies.Length - 1;
        }

        // 적 객체 정의
        Instantiate(ememies[index], spawnPos, Quaternion.identity);
    }
}
