using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�ִϸ��̼� ���� ����
    public enum State { Idle, Run, Jump, Hit, Die };
    public float startJumpPower;
    public float jumpPower;
    public bool isGround;
    public bool isJumpkey;
    public bool isSlideKey = false;
    private float crouchHeight = 0.5f;
    public float savespeed;
    public float savesmobspeed;
    public bool isDash = false;

    Transform t;
    Rigidbody2D rigid;
    Animator anim;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        t = GetComponent<Transform>();
    }

    void Start()
    {
        if (!GameManager.instance.isPlay)
            ChangeAnim(State.Idle);
    }
    void Update()
    {
        // �⺻ ����
        if (Input.GetButtonDown("Jump") && isGround && !isSlideKey && GameManager.instance.isPlay)
        {
            rigid.AddForce(Vector2.up * startJumpPower, ForceMode2D.Impulse);
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Jump);
        }

        isJumpkey = Input.GetButton("Jump");

        //�����̵�
        if (Input.GetButtonDown("Slide") && isGround && !isJumpkey && GameManager.instance.isPlay)
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
        if (!isGround && GameManager.instance.isPlay)
        {
            ChangeAnim(State.Run);
            jumpPower = 1;
        }

        isGround = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        ChangeAnim(State.Jump);
        isGround = false;
    }

    //��ֹ� �浹
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle" && !isDash)
        {
            if (GameManager.instance.hp <= 0)
            {
                ChangeAnim(State.Die);
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Dead);
                rigid.simulated = false;
                GameManager.instance.GameOver();
            }
            else
            {
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Hit);
                GameManager.instance.hp--;
                StartCoroutine(Hit());
            }
        }
        else if (collision.tag == "giftbox" && !isDash)
        {
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Dash);
            collision.gameObject.SetActive(false);
            Dash();
        }
        else if (collision.tag == "cake")
        {
            collision.gameObject.SetActive(false);
            if (GameManager.instance.hp < 3)
            {
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Hp);
                GameManager.instance.hp++;
            }
            else
            {
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Hpplus);
                GameManager.instance.score += 10;
            }
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
        yield return new WaitForSeconds(0.5f);
        ChangeAnim(State.Run);
    }

    void Dash()
    {
        if (GameManager.instance.stack <= 4)
        {
            GameManager.instance.stack++;

            if (GameManager.instance.stack >= 5)
            {
                StartCoroutine(DashSpeed());
            }
        }
    }

    IEnumerator DashSpeed()
    {
        savespeed = GameManager.instance.gameSpeed;
        savesmobspeed = GameManager.instance.mobSpeed;
        GameManager.instance.gameSpeed = 10;
        GameManager.instance.mobSpeed = 13;
        GameManager.instance.scorespeed = 0.1f;
        isDash = true;
        AudioManager.instance.PlayBgm(AudioManager.Bgm.Dash);
        yield return new WaitForSeconds(10f);
        GameManager.instance.gameSpeed = savespeed;
        GameManager.instance.mobSpeed = savesmobspeed;
        GameManager.instance.stack = 0;
        isDash = false;
        AudioManager.instance.PlayBgm(AudioManager.Bgm.Stage);
    }

}
