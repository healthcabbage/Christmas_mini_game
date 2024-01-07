using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�ִϸ��̼� ���� ����
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

    // 1. ���� (���� �Ŀ�)
    // 2. ���� (���� �浹 �̺�Ʈ)
    // 3. ��ֹ� ��ġ (Ʈ���� �浹 �̺�Ʈ)
    // 4. �����̵� (�̲�������)
    // 5. ��ġ (���� ���� �μ���)
    // 6. �ִϸ��̼�
    // 7. ���� (������)
}
