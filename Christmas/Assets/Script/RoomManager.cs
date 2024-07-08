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

    //�� ó�� �ؽ�Ʈ ���
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

    //�ؽ�Ʈ ȿ��
    IEnumerator TypingRoutine(string text)
    {
        int typingLength = originText.GetTypingLength();

        for (int index = 0; index <= typingLength; index++)
        {
            Text.text = originText.Typing(index);
            yield return new WaitForSeconds(0.01f);
        }
    }

    //ù Ʃ�丮�� ���
    void Tutorial()
    {
        first.SetActive(true);
        switch(tutorial_num)
        {
            case 0:
                Text.text = ("�� ��... ������ ���ͼ� ���� ���İ���!");
                originText = Text.text;
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Talk);
                StartCoroutine(TypingRoutine(originText));
                break;
            case 1:
                Text.text = ("��� ����? �̴�ζ�� �־��� ũ���������� �ɰž�.");
                originText = Text.text;
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Talk);
                StartCoroutine(TypingRoutine(originText));
                break;
            case 2:
                Text.text = ("�̰� ����? ũ�������� Ư�� �� ����? ���� ���԰� ����ɱ�?");
                originText = Text.text;
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Talk);
                StartCoroutine(TypingRoutine(originText));
                break;
            case 3:
                Text.text = ("�� ������ ���� �� �����ϱ�, �ϴ��� �̰��� �����߰ڳ�...");
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
