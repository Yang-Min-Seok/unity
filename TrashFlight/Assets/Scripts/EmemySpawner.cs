using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemySpawner : MonoBehaviour
{   
    // 적 저장
    [SerializeField]
    private GameObject[] ememies;

    [SerializeField]
    private GameObject Boss;

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

        // 이동 속도
        float moveSpeed = 5f;
        // 생성횟수
        int spawnCount = 0;
        // 생성할 적의 인덱스
        int enemyIndex = 0;

        while (true) {
            // arrPosX에서 posX를 하나씩 꺼내 반복
            foreach(float posX in arrPosX) {
                // 생성하기
                SpawnEnemy(posX, enemyIndex, moveSpeed);
            }

            spawnCount++;

            if (spawnCount % 10 == 0) {
                enemyIndex++;
                moveSpeed += 2;
            }

            // 적 배열 길이보다 인덱스가 커지면 보스 등장시키기
            if (enemyIndex >= ememies.Length) {
                SpawnBoss();
                // 같이 내려오는 적들 인덱스 초기화
                enemyIndex = 0;
                moveSpeed = 5f;
            }
            
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // 적 생성 함수
    void SpawnEnemy(float posX, int index, float moveSpeed) {
        
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
        GameObject enemyObject = Instantiate(ememies[index], spawnPos, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        enemy.SetMoveSpeed(moveSpeed);
    }

    void SpawnBoss() {
        Instantiate(Boss, transform.position, Quaternion.identity);
    }
}
