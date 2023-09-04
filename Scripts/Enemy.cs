using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 목표 아래로 계속 이동
    // 필요 속성: 이동 속도
    public float speed = 5;
    // 방향을 전역변수로 만들어 start 와 update에 사용
    Vector3 dir;

    //목표: 적이 다른 물체와 충돌했을 때 폭발 효과를 발생시키고 싶다.
    //순서: 1. 적이 다른 물체와 충돌했으니까.(이벤트 감지)
    //      2. 폭발 효과 공장에서 폭발 효과를 하나 만들어야 한다.
    //      3. 폭발 효과를 발생(위치) 시키고 싶다.
    //필요속성: 폭발 공장 주소(외부에서 값을 넣어준다)
    public GameObject explosionFactory;

    private void OnEnable()
    {
        //30% 확률로 플레이어 방향으로 날아가게 하고 싶다. 
        // 0~9중에 숫자 랜덤 생성
        int randValue = UnityEngine.Random.Range(0, 10);
        // 만약 3보다 작으면 플레이어 방향
        if (randValue < 3)
        {
            //플레이어를 찾아 target으로 하고 싶다.
            GameObject target = GameObject.Find("Player");
            //방향을 구하고 싶다.target - me 백터의 성질
            dir = target.transform.position - transform.position;
            //방향의 크기를 1로 하고 싶다.
            dir.Normalize();

        }
        //그렇지 않다면 아래방향
        else
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        // 1.방향을 구한다. 시작할 때 구함
        // 2.이동 P = PO + vt
        transform.position += dir * speed * Time.deltaTime;
    }

    //충돌시작
    private void OnCollisionEnter(Collision other)
    {
        //에너미를 잡을 때마다 현재 점수를 표시하고 싶다.
        ScoreManager.Instance.Score++;

        //충돌이팩트 생성
        GameObject explosion = Instantiate(explosionFactory);
        //충돌이팩트 발생
        explosion.transform.position = transform.position;

        //만약 부딪힌 객체가 Bullet인 경우에는 비활성화시켜 탄창에 다시 넣어준다.
        //1. 만약 부딪힌 물체가 Bullet이라면
        if (other.gameObject.name.Contains("Bullet"))
        {
            //2.부딪힌 물체을 비활성화
            other.gameObject.SetActive(false);
        }
        // 3. 그렇지 않으면제거
        else
        {
            Destroy(other.gameObject);
        }
        //없애는 대신. 비활성화해 풀에 자원 반납
        //Destroy(gameObject);
        gameObject.SetActive(false );
    }
}
