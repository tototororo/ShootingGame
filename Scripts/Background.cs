using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // 배경 머티리얼
    public Material bgMaterial;
    // 스크롤 속도
    public float scrollSpeed = 0.2f ;


    void Update()
    {
        // 방향  x,y로 충분 vector2사용
        Vector2 dir = Vector2.up;
        // 스크롤 하고 싶다(이동) P = PO + vt
        bgMaterial.mainTextureOffset += dir * scrollSpeed * Time.deltaTime;
    }

}
