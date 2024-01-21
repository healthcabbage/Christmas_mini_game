using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�ִϸ��̼� ���� ����
    public enum State { Idle, Run, Jump, Punch, Hit, Die };
    public float startJumpPower;
    public float jumpPower;
    public bool isGround;
    public bool isJumpkey;
    public bool isSlideKey = false;
    private float crouchHeight = 0.5f;

    Transform t;
    Rigidbody2D rigid;
    Animator anim;
    public GameObject punch_obj;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        t = GetComponent<Transform>();
    }

    void Update()
    {
        // �⺻ ����
        if (Input.GetButtonDown("Jump") && isGround && !isSlideKey)
        {
            rigid.AddForce(Vector2.up * startJumpPower, ForceMode2D.Impulse);
        }

        isJumpkey = Input.GetButton("Jump");

        //�����̵�
        if (Input.GetButtonDown("Slide") && isGround)
        {
            isSlideKey = Input.GetButtonDown("Slide");
            t.localScale = new Vector3(crouchHeight, crouchHeight, t.localScale.z);
            t.position = new Vector3(-6, -2.2f, 0);
        }

        if (Input.GetButtonUp("Slide"))
        {
            t.localScale = new Vector3(1f, 1f, t.localScale.z);
            t.position = new Vector3(-6, -1.8f, 0);
            isSlideKey = false;
        }
    }

    // �� ����
    void FixedUpdate()
    {
        if (isJumpkey && !isGround)
        {
            jumpPower = Mathf.Lerp(jumpPower, 0, 0.1f);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    // 2. ���� (���� �浹 �̺�Ʈ)
    void OnCollisionStay2D(Collision2D collision)
    {
        if (!isGround)
        {
            ChangeAnim(State.Run);
            //����
            jumpPower = 1;
        }

        isGround = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        ChangeAnim(State.Jump);
        //����
        isGround = false;
    }

    //��ֹ� �浹
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            if (GameManager.instance.hp <= 0)
            {
                ChangeAnim(State.Die);
                rigid.simulated = false;
            }
            else
            {
                GameManager.instance.hp--;
                StartCoroutine(Hit());
            }
        }
        else if (collision.tag == "giftbox")
        {

        }
    }

    // �ִϸ��̼�
    void ChangeAnim(State state)
    {
        anim.SetInteger("State", (int)state);
    }

    //�浹 �� �̺�Ʈ
    IEnumerator Hit()
    {
        ChangeAnim(State.Hit);
        //����


        yield return new WaitForSeconds(0.5f);
        ChangeAnim(State.Run);
    }

    void Dash()
    {
        if (GameManager.instance.stack < 6)
            GameManager.instance.stack++;
        else
            GameManager.instance.stack = 0;
    }

}
