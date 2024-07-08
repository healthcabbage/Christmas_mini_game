using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using KoreanTyper;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    string originText;
    public int num;
    public TMP_Text Text;
    public Image image;
    public Sprite[] images;

    public GameObject next;
    public bool isnext = false;

    void Start()
    {
        AudioManager.instance.PlayBgm(AudioManager.Bgm.Story);
        story();
    }

    public void plus()
    {
        switch (num)
        {
            case 0:
                ++num;
                story();
                break;
            case 1:
                ++num;
                story();
                break;
            case 2:
                ++num;
                story();
                break;
            case 3:
                ++num;
                story();
                break;
            case 4:
                ++num;
                story();
                break;
            case 5:
                ++num;
                story();
                break;
            case 6:
                ++num;
                story();
                nextbutton();
                break;
        }
    }

    public void minus()
    {
        switch (num)
        {
            case 1:
                --num;
                story();
                break;
            case 2:
                --num;
                story();
                break;
            case 3:
                --num;
                story();
                break;
            case 4:
                --num;
                story();
                break;
            case 5:
                --num;
                story();
                break;
            case 6:
                --num;
                story();
                break;
            case 7:
                --num;
                story();
                nextbutton();
                break;
        }
    }

    public void storytext()
    {
        switch (num)
        {
            case 0:
                Text.text = ("�װ��� ũ�������� �� �Ͼ ���̿����ϴ�.");
                originText = Text.text;
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Talk);
                StartCoroutine(TypingRoutine(originText));
                break;
            case 1:
                Text.text = ("���� �׸���� �ҳడ �־����ϴ�.");
                originText = Text.text;
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Talk);
                StartCoroutine(TypingRoutine(originText));
                break;
            case 2:
                Text.text = ("�׳�� �׳ุ�� ���� ������ �;���, ���ϸ��� ������ ���� �ؼ� ��ħ�� �׳��� ���� ��� �Ǿ����ϴ�.");
                originText = Text.text;
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Talk);
                StartCoroutine(TypingRoutine(originText));
                break;
            case 3:
                Text.text = ("�׸��� ��ſ� ũ���������� ������ ���ؼ� ������ �ɾ�� ���̿����ϴ�.");
                originText = Text.text;
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Talk);
                StartCoroutine(TypingRoutine(originText));
                break;
            case 4:
                Text.text = ("�׸��� ��𿡼��� '�����̾�!' ��� �Ҹ��� ��� �Ǿ����ϴ�.");
                originText = Text.text;
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Talk);
                StartCoroutine(TypingRoutine(originText));
                break;
            case 5:
                Text.text = ("ũ���������� �����̶��, ������ ���� ������ ����̳׿�.");
                originText = Text.text;
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Talk);
                StartCoroutine(TypingRoutine(originText));
                break;
            case 6:
                Text.text = ("�׸��� ���� ���� ���� �׳�� �ڽ��� ���� ������ ���� ���ϸ��� ���� ���� �˴ϴ�.");
                originText = Text.text;
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Talk);
                StartCoroutine(TypingRoutine(originText));
                break;
            case 7:
                Text.text = ("������ ���� ���� �츮���̿���...?");
                originText = Text.text;
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Talk);
                StartCoroutine(TypingRoutine(originText));
                break;
        }

    }

    public void story()
    {
        switch(num)
        {
            case 0:
                storytext();
                storyImage();
                break;
            case 1:
                storytext();
                storyImage();
                break;
            case 2:
                storytext();
                storyImage();
                break;
            case 3:
                storytext();
                storyImage();
                break;
            case 4:
                storytext();
                storyImage();
                break;
            case 5:
                storytext();
                storyImage();
                break;
            case 6:
                storytext();
                storyImage();
                break;
            case 7:
                storytext();
                storyImage();
                break;
        }
    }

    IEnumerator TypingRoutine(string text)
    {
        int typingLength = originText.GetTypingLength();

        for (int index = 0; index <= typingLength; index++)
        {
            Text.text = originText.Typing(index);
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void storyImage()
    {
        switch (num)
        {
            case 0:
                image.sprite = images[0];
                break;
            case 1:
                image.sprite = images[1];
                break;
            case 2:
                image.sprite = images[2];
                break;
            case 3:
                image.sprite = images[3];
                break;
            case 4:
                image.sprite = images[4];
                break;
            case 5:
                image.sprite = images[5];
                break;
            case 6:
                image.sprite = images[6];
                break;
            case 7:
                image.sprite = images[7];
                break;
        }
    }

    public void nextbutton()
    {
        if (isnext == false)
        {
            next.SetActive(true);
            isnext = true;
        }
        else
        {
            next.SetActive(false);
            isnext = false;
        }
    }

    public void move()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
        SceneManager.LoadScene("Room");
    }
}
