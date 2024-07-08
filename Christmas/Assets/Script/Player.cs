using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //애니메이션 현재 상태
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

    public bool isDead = false;
    public bool isHit = false;

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
        // 기본 점프
        if (Input.GetButtonDown("Jump") && isGround && !isSlideKey && GameManager.instance.isPlay)
        {
            rigid.AddForce(Vector2.up * startJumpPower, ForceMode2D.Impulse);
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Jump);
        }

        isJumpkey = Input.GetButton("Jump");

        //슬라이드
        if (Input.GetButtonDown("Slide") && isGround && !isJumpkey && GameManager.instance.isPlay)
        {
            isSlideKey = Input.GetButtonDown("Slide");
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Small);
            t.localScale = new Vector3(crouchHeight, crouchHeight, t.localScale.z);
            t.position = new Vector3(-6, -2.2f, 0);
        }

        if (Input.GetButtonUp("Slide"))
        {
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Big);
            t.localScale = new Vector3(1f, 1f, t.localScale.z);
            t.position = new Vector3(-6, -1.8f, 0);
            isSlideKey = false;
        }

        if (GameManager.instance.hp <= 0 && !isDead)
        {
            ChangeAnim(State.Die);
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Dead);
            rigid.simulated = false;
            GameManager.instance.GameOver();
            isDead = true;
        }
    }

    // 롱 점프
    void FixedUpdate()
    {
        if (isJumpkey && !isGround)
        {
            jumpPower = Mathf.Lerp(jumpPower, 0, 0.1f);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    // 2. 착지 (물리 충돌 이벤트)
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

    //장애물 충돌
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle" && !isDash && !isHit)
        {
            if (GameManager.instance.hp >= 0)
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

    // 애니메이션
    void ChangeAnim(State state)
    {
        anim.SetInteger("State", (int)state);
    }

    //충돌 시 이벤트
    IEnumerator Hit()
    {
        ChangeAnim(State.Hit);
        isHit = true;
        yield return new WaitForSeconds(0.5f);
        ChangeAnim(State.Run);
        isHit = false;
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
        GameManager.instance.scorespeed = 0.5f;
        AudioManager.instance.PlayBgm(AudioManager.Bgm.Stage);
    }

}
