using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSystem : MonoBehaviour
{
    public void Room()
    {
        SceneManager.LoadScene("Room");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Story()
    {
        SceneManager.LoadScene("Story");
    }

    public void MainGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    // room or story
    // 메인 게임 첫 시작 시에만, story로 갈지 room으로 갈지 체크하는 함수
    public void Tutorial()
    {
        bool istutorial = GameManager.instance.data.isRoom_story;
        if (istutorial)
        {
            Story();
            GameManager.instance.data.isRoom_story = false;
        }
        else
        {
            Room();
        }

    }
}
