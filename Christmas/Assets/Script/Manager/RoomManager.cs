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

    void Start()
    {
        GameManager.instance.audiosystem.PlayBgm(AudioSystem.Bgm.Room);
        Tutorial();
    }

    //첫 튜토리얼 대사
    void Tutorial()
    {
        first.SetActive(true);
        switch(tutorial_num)
        {
            case 0:
                GameManager.instance.texteffect.originText = GameManager.instance.data.RoomTutorial_text[tutorial_num];
                Text.text = GameManager.instance.texteffect.originText.ToString();
                GameManager.instance.audiosystem.PlaySfx(AudioSystem.Sfx.Talk);
                StartCoroutine(GameManager.instance.texteffect.TypingRoutine(Text));
                break;
            case 1:
                GameManager.instance.texteffect.originText = GameManager.instance.data.RoomTutorial_text[tutorial_num];
                Text.text = GameManager.instance.texteffect.originText.ToString();
                GameManager.instance.audiosystem.PlaySfx(AudioSystem.Sfx.Talk);
                StartCoroutine(GameManager.instance.texteffect.TypingRoutine(Text));
                break;
            case 2:
                GameManager.instance.texteffect.originText = GameManager.instance.data.RoomTutorial_text[tutorial_num];
                Text.text = GameManager.instance.texteffect.originText.ToString();
                GameManager.instance.audiosystem.PlaySfx(AudioSystem.Sfx.Talk);
                StartCoroutine(GameManager.instance.texteffect.TypingRoutine(Text));
                break;
            case 3:
                GameManager.instance.texteffect.originText = GameManager.instance.data.RoomTutorial_text[tutorial_num];
                Text.text = GameManager.instance.texteffect.originText.ToString();
                GameManager.instance.audiosystem.PlaySfx(AudioSystem.Sfx.Talk);
                StartCoroutine(GameManager.instance.texteffect.TypingRoutine(Text));
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
        GameManager.instance.audiosystem.PlaySfx(AudioSystem.Sfx.Button);
        GameManager.instance.scene.Shop();
    }

    public void Stage()
    {
        GameManager.instance.audiosystem.PlaySfx(AudioSystem.Sfx.Button);
        GameManager.instance.scene.MainGame();
    }
}
