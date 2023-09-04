using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 목표 : 위로 계속 이동
    // 필요속성 : 이동속도
    public float speed = 5;

    // Update 파트 (프로그램 동작동안 반복작업)
    void Update()
    {
        // 1. 방향을 구한다
        Vector3 dir = Vector3.up ;
        // 2. 이동하고 싶다. 공식 P = PO + vt ,  미래의 위치 = 현재위치 + 방향 * 속도 * 시간(환경간 차이를 없애기 위한 동기화 함수임)
        transform.position += dir * speed * Time.deltaTime; 
    }
}
