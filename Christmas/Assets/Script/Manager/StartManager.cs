using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public GameObject option;
    public bool Tuto_check;
    bool check;

    void Start()
    {
        GameManager.instance.audiosystem.PlayBgm(AudioSystem.Bgm.Start);
        Tuto_check = GameManager.instance.data.isfirststory;
    }

    public void Game()
    {
        GameManager.instance.audiosystem.PlaySfx(AudioSystem.Sfx.Button);
        if (Tuto_check)
        {
            GameManager.instance.scene.MainGame();
        }
        else
        {
            GameManager.instance.scene.Tutorial();
        }

    }

    public void setting()
    {
        GameManager.instance.audiosystem.PlaySfx(AudioSystem.Sfx.Button);

        if (check == false)
        {
            option.SetActive(true);
            check = true;
        }
        else
        {
            option.SetActive(false);
            check = false;
        }
    }
}
