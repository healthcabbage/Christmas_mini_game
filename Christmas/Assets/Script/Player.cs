using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //애니메이션 현재 상태
    public enum State { Idle, Run, Jump, Slide, Break, Hit };
    public float startJumpPower;
    public float jumpPower;
    public bool isGround;

    Rigidbody2D rigid;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    // 1. 점프 (점프 파워)
    // 2. 착지 (물리 충돌 이벤트)
    // 3. 장애물 터치 (트리거 충돌 이벤트)
    // 4. 슬라이드 (미끄러지기)
    // 5. 펀치 (선물 상자 부수기)
    // 6. 애니메이션
    // 7. 사운드 (마지막)
}
