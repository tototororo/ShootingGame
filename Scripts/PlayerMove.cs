using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 목표 : 방향키로 이동
    // 플레이어가 이동할 속력
    public float speed = 5 ;

    // Update 파트 (프로그램 동작동안 반복작업)
    void Update()
    {
        //방향 키보드 입력값 h=가로 v=세로
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        // 방향 입력값 백터값으로 변경
        Vector3 dir = new Vector3(h,v,0);

        // P = PO + vt 공식으로 변경 , transform.Translate() 함수가 유니티 종속적임
        // transform.Translate(dir * speed * Time.deltaTime);
        transform.position += dir * speed * Time.deltaTime ;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
