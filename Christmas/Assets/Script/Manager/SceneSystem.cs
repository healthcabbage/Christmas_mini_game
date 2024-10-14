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
    // ���� ���� ù ���� �ÿ���, story�� ���� room���� ���� üũ�ϴ� �Լ�
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
