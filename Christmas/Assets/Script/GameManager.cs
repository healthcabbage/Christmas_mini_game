using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("# Game Data")]
    public int hp;
    public int stack;
    public float gameSpeed;
    public float mobSpeed;
    public int score = 0;
    public bool isPlay = false;
    public float scorespeed;

    public delegate void OnPlay(bool isplay);
    public OnPlay onPlay;

    bool check = false;

    [Header("# GameObj")]
    public GameObject playBtn;
    public GameObject Over;
    public GameObject Setting;
    public GameData data;

    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBtnClick()
    {
        playBtn.SetActive(false);
        isPlay = true;
        onPlay.Invoke(isPlay);
        StartCoroutine(AddScore());
        AudioManager.instance.PlayBgm(AudioManager.Bgm.Stage);
    }

    public void GameOver()
    {
        Over.SetActive(true);
        data.star = score;
        isPlay = false;
        onPlay.Invoke(isPlay);
        AudioManager.instance.StopBgm();
    }

    public void Room()
    {
        //사운드
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
        SceneManager.LoadScene("Room");
    }

    public void Replay()
    {
        //사운드
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
        SceneManager.LoadScene("Maingame");
    }

    IEnumerator AddScore()
    {
        while(isPlay)
        {
            score++;
            yield return new WaitForSeconds(scorespeed);
        }
    }

    public void option()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
        if (check == false)
        {
            Setting.SetActive(true);
            Time.timeScale = 0;
            check = true;
        }
        else
        {
            Setting.SetActive(false);
            Time.timeScale = 1;
            check = false;
        }
    }

}
