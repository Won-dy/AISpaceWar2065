using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float currentTime; // 시간을 재기 위한 현재시간
    public float createTime; // 1초에 한번씩 적을 생성
    public GameObject enemyFactory; // 에너미 프리팹
    public float minTime;
    public float maxTime;
    public int poolSize; //에너미 오브젝트 풀 사이즈
     // GameObject[] enemyObjectPool; // 에너미 오브젝트 풀
    public List<GameObject> enemyObjectPool;
    public Transform[] spawnPoints; //SpawnPoint들
    // Start is called before the first frame update
    void Start()
    {
        if (name == "ChargeHPManager" || name == "Item_Star_Manager" || name == "PowerUpManager")
            createTime = Random.Range(10.0f, 20.0f);
        if (name.Contains("EnemyManager"))
            createTime = Random.Range(1.0f, 5.0f);
        if (name == "FlareObstacleManager" || name == "Enemy2Manager")
            createTime = Random.Range(5.0f, 10.0f);

        //  enemyObjectPool = new GameObject[poolSize];
        enemyObjectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory); //에너미 오브젝트풀에 에너미 생성
            //enemyObjectPool[i] = enemy;
            enemyObjectPool.Add(enemy);
            enemy.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime; //시간을 누적
        // print("현재시간 : " + currentTime + "생성시간 : "+ createTime);
        if (currentTime > createTime)
        {
            if (enemyObjectPool.Count > 0) //오브젝트 풀에 에너미가 있다면..//오브젝트풀을 리스트로 사용했을 때...
            {
                GameObject enemy = enemyObjectPool[0];//오브젝트풀에서 에너미를 가져다 사용함
                enemyObjectPool.Remove(enemy); // 오브젝트풀에서 에너미 제거
                enemy.SetActive(true); // 에너미 활성화
                int index = Random.Range(0, spawnPoints.Length); // 랜덤으로 인덱스 선택
                enemy.transform.position = spawnPoints[index].position; //에너미 위치시키기
            }
            /*
            for (int i = 0; i < poolSize; i++) //오브젝트풀을 배열로 사용했을 때...
            {
                print("Enemy생성"+i);
                GameObject enemy = enemyObjectPool[i];
                if (enemy.activeSelf == false) //오브젝트 풀을 돌며 비활성화를 활성화로 바꿔줌
                {
                    //   enemy.transform.position = transform.position; //에너미 좌표설정
                   
                    enemy.SetActive(true);
                    int index = Random.Range(0, spawnPoints.Length);
                    enemy.transform.position = spawnPoints[index].position;
                    break;
                }
            }
            */
            currentTime = 0;// 시간을 다시 0으로 초기화
            createTime = Random.Range(minTime, maxTime);
        }
      //  GameObject enemy = Instantiate(enemyFactory); //에너미 생성
        
       
    }
}
