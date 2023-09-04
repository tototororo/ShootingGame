using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 오브젝트 풀 크기
    public int poolSize = 10;
    // 오브젝트 풀 배열
    GameObject[] enemyObjectPool;
    //Spawn Point들
    public Transform[] spawnPoints;

    //적이 생성될 때마다 다음 생성 시간을 랜덤하게 바꾸기
    //최소 시간
    float minTime = 0.5f;
    //최대 시간
    float maxTime = 1.5f;

    //현재시간
    float currentTime;
    //일정시간
    public float createTime ;
    //적 공장
    public GameObject enemyFactory;

    private void Start()
    {
        //태어날 때 적의 생성 시간을 설정하고
        createTime = UnityEngine.Random.Range(minTime,maxTime);

        //오브젝트 풀을 에너미들을 담을 수 있는 크기로 만들어준다.
        enemyObjectPool = new GameObject[poolSize];
        //오브젝트 풀에 넣을 에너미 개수만큰 반복해
        for(int i = 0; i < poolSize; i++)
        {
            //공장에 에너미 생성
            GameObject enemy = Instantiate(enemyFactory);
            //에너미를 오브젝트풀에 넣고 싶다.
            enemyObjectPool[i] = enemy;
            //비활성화
            enemy.SetActive(false);
        }
    }

    void Update()
    {
        // 1. 시간이 흐르다가
        currentTime += Time.deltaTime;
        //2. 만약 현재 시간이 일정 시간이 되면
        if (currentTime > createTime)
        {
            //에너미풀 안에 잇는 에너미들 중에서
            for(int i = 0;i < poolSize; i++)
            {
                GameObject enemy = enemyObjectPool[i];
                if (enemy.activeSelf == false)
                {
                    //랜덤으로 인덱스 선택
                    int index = Random.Range(0,spawnPoints.Length);
                    // 내 위치에 갖다 놓고 싶다.
                    enemy.transform.position = spawnPoints[index].position;
                    //에너미 활성화.
                    enemy.SetActive(true);
                    //에너미 활헝화 하였기 때문에 검색 중단
                    break;
                }
                   
            }

            //현재 시간을 0으로 초기화(계속 생성을 막기위해)
            currentTime = 0;
            //적을 생성한 후 적의 생성 시간을 다시 랜덤으로 설정하고 싶다.
            createTime = UnityEngine.Random.Range(minTime, maxTime);

        }
    }
}
