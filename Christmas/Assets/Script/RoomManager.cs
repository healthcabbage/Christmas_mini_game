using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using KoreanTyper;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    string originText;
    public TMP_Text Text;

    public GameData data;

    //맨 처음 텍스트 출력
    public GameObject first;
    public int tutorial_num;
    public bool tutorial;

    public GameObject buttons;
    public GameObject Endbuttons;

    void Awake()
    {
        
    }

    void Start()
    {
        AudioManager.instance.PlayBgm(AudioManager.Bgm.Room);
        Tutorial();
    }

    //텍스트 효과
    IEnumerator TypingRoutine(string text)
    {
        int typingLength = originText.GetTypingLength();

        for (int index = 0; index <= typingLength; index++)
        {
            Text.text = originText.Typing(index);
            yield return new WaitForSeconds(0.01f);
        }
    }

    //첫 튜토리얼 대사
    void Tutorial()
    {
        first.SetActive(true);
        switch(tutorial_num)
        {
            case 0:
                Text.text = ("내 집... 도둑이 들어와서 전부 훔쳐갔어!");
                originText = Text.text;
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Talk);
                StartCoroutine(TypingRoutine(originText));
                break;
            case 1:
                Text.text = ("어떻게 하지? 이대로라면 최악의 크리스마스가 될거야.");
                originText = Text.text;
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Talk);
                StartCoroutine(TypingRoutine(originText));
                break;
            case 2:
                Text.text = ("이게 뭐지? 크리스마스 특별 대 할인? 새로 가게가 생긴걸까?");
                originText = Text.text;
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Talk);
                StartCoroutine(TypingRoutine(originText));
                break;
            case 3:
                Text.text = ("빈 집으로 지낼 순 없으니까, 일단은 이곳에 가봐야겠네...");
                originText = Text.text;
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Talk);
                StartCoroutine(TypingRoutine(originText));
                break;
        }

    }

    public void Tuto_num()
    {
        switch(tutorial_num)
        {
            case 0:
                ++tutorial_num;
                Tutorial();
                break;
            case 1:
                ++tutorial_num;
                Tutorial();
                break;
            case 2:
                ++tutorial_num;
                Tutorial();
                break;
            case 3:
                first.SetActive(false);
                buttons.SetActive(true);
                break;
        }
    }

    public void Shop()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
        SceneManager.LoadScene("Shop");
    }

    public void Stage()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
        SceneManager.LoadScene("MainGame");
    }
}
