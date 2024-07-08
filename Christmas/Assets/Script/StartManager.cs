using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public GameObject option;

    bool check;
    void Start()
    {
        AudioManager.instance.PlayBgm(AudioManager.Bgm.Start);
    }

    void Update()
    {
        
    }

    public void Game()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
        SceneManager.LoadScene("Story");
    }

    public void setting()
    {
        if (check == false)
        {
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
            option.SetActive(true);
            check = true;
        }
        else
        {
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
            option.SetActive(false);
            check = false;
        }
    }
}
