using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    //영역안에 다른 물체가 감지될 경우
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 옵젝 파괴
        //Destroy(ohter.gameObject);
        // 오브젝트 풀이므로 전부 비활성화
        other.gameObject.SetActive(false);
    }
}
